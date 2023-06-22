using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody _rig;
    float _speed;

    float _damage = 10f;
    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        _rig.AddForce(transform.forward * 30f);
        _rig.AddForce(transform.up * 15f);
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

            Destroy(gameObject);
        }
    }
}
