using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody _rig;
    float _speed;

    float _damage = 10f;
    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
        _rig.AddForce(transform.forward * 15f, ForceMode.Impulse);
        _rig.AddForce(transform.up * 5f, ForceMode.Impulse);
    }
    public void Init(float speed)
    {
        this._speed = speed;
        Destroy(gameObject, 1.3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthManager>().MinusHealth(_damage);
            Destroy(gameObject);
        }
    }
}
