using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    Rigidbody _rig;
    float _speed;

    float _damage = 10f;
    RaycastHit hit;
    Ray ray;
    int layerMask;
    bool result;
    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
        layerMask = 1 << LayerMask.NameToLayer("Enemy");
        Physics.IgnoreLayerCollision(10,10);
    }

    private void FixedUpdate()
    {
        _rig.AddForce(transform.forward * _speed);
    }

    private void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        result = Physics.Raycast(ray, out hit, 0.1f, layerMask);

        if (result)
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                GameObject obj = hit.collider.gameObject;
                obj.GetComponent<HealthManager>().MinusHealth(_damage);
                Destroy(gameObject);
            }
        }
    }
    
    
    public void Init(float speed)
    {
        this._speed = speed;
        Destroy(gameObject, 2.0f);
    }
}
