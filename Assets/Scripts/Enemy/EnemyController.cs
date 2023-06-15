using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _health;
    Rigidbody _rig;
    public float _dealtDamage;
    

    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
        gameObject.GetComponent<HealthManager>().SetHealth(_health);
    }

    

    void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("PlayerBullet")){
            GameObject bullet = other.gameObject;
            _dealtDamage = bullet.GetComponent<PistolBullet>().getDamage();
            gameObject.GetComponent<HealthManager>().MinusHealth(_dealtDamage);
        }
    }
}
