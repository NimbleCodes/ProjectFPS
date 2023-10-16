using UnityEngine;
using UnityEngine.UI;

public class BulletCustom : MonoBehaviour
{
    [SerializeField] Rigidbody _rig;
    [SerializeField] GameObject _explosion;
    [SerializeField] LayerMask _isEnemy;
    [SerializeField] bool useGravity;
    [SerializeField] bool explosionEnable;
    [SerializeField] int explosionDamage;
    [SerializeField] float explosionRange;
    [SerializeField] float explosionForce;
    [SerializeField] float lifeTime;

    [Header("Grenade Launcher")]
    [SerializeField] float dropTime;
    [SerializeField] float waitMidAir;
    [SerializeField] float dropForce;
    [SerializeField] bool explodeAfterDrop = true;

    PhysicMaterial physic_mat;

    private void Start() {
        Init_Mat();
    }

    private void Update() {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0) Explode();

        if(dropTime != 0) DropDown();
    }

    void Init_Mat(){
        physic_mat = new PhysicMaterial();
        physic_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        
        GetComponent<SphereCollider>().material = physic_mat;

        _rig.useGravity = useGravity;
    }

    void DropDown(){
        dropTime -= Time.deltaTime;

        if (dropTime <= 0)
        {
            dropTime = 100;

            if (dropForce > 0)
            _rig.useGravity = false;
            _rig.velocity = Vector3.zero;

            if (waitMidAir == 0)
                _rig.AddForce(Vector3.down * dropForce, ForceMode.Impulse);
            else
                Invoke("LateDropDown", waitMidAir);
        }
    }
    void LateDropDown() { _rig.AddForce(Vector3.down * dropForce, ForceMode.Impulse); }
    

    void Explode(){
        if (_explosion != null) Instantiate(_explosion, transform.position, Quaternion.identity);

        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, _isEnemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<HealthManager>().MinusHealth(explosionDamage);

            if (enemies[i].GetComponent<Rigidbody>())
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange);
        }

        Invoke("Delay", 0.05f);
    }
    void Delay(){
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Bullet")) return;

        if(other.collider.CompareTag("Enemy") && explosionEnable) Explode();

        if(other.collider.CompareTag("Ground")) Explode();
    }
}
