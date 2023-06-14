using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform _shootPoint;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _camRotation;
    GameObject Bullet;
    float x,y,z;
    void Update()
    {
        x = Mathf.Cos(_camRotation.rotation.x * Mathf.Deg2Rad);
        y = Mathf.Sin(_camRotation.rotation.y * Mathf.Deg2Rad);
        z = _shootPoint.transform.rotation.z;
        if (Input.GetMouseButtonDown(0))
        { 
            Bullet = Instantiate(_bulletPrefab,_shootPoint.position,transform.rotation);
            Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 600);
            Destroy(Bullet, 1f);
            //Bullet.GetComponent<PistolBullet>().Init(x,y,z,20);

        }
    }
}
