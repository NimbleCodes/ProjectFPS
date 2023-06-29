using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform _shootPoint;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _aimPoint;
    GameObject Bullet;
    void Update()
    {
        _shootPoint.LookAt(_aimPoint);
        if (Input.GetMouseButtonDown(0))
        { 
            Bullet = Instantiate(_bulletPrefab,_shootPoint.position,transform.rotation);
            Bullet.GetComponent<PistolBullet>().Init(400);
           
        }
    }
}
