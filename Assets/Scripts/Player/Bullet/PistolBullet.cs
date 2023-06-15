using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    Rigidbody _rig;
    float _speed;

    float _damage = 10f;
    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rig.AddForce(transform.forward * _speed);
    }
    public float getDamage(){
        return _damage;
    }
    public void Init(float speed)
    {
        this._speed = speed;
        Destroy(gameObject, 1.3f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
