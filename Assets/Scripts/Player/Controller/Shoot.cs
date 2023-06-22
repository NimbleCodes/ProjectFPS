using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform _shootPoint;
    [SerializeField] GameObject _bulletPrefab;
    GameObject Bullet;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Bullet = Instantiate(_bulletPrefab,_shootPoint.position,transform.rotation);
            Bullet.GetComponent<PistolBullet>().Init(400);
           
        }
    }
}
