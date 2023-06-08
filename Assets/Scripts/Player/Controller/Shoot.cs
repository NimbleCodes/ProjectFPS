using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform _shootPoint;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _camRotation;
    GameObject Bullet;
    float x,y;
    void Update()
    {
        x = Mathf.Cos(_camRotation.rotation.x * Mathf.Deg2Rad);
        y = Mathf.Sin(_camRotation.rotation.y * Mathf.Deg2Rad);
        if (Input.GetMouseButtonDown(0))
        { 
            Bullet = Instantiate(_bulletPrefab,_shootPoint.position,_camRotation.rotation);
            Bullet.GetComponent<Rigidbody>().AddForce(new Vector3(x,y,_shootPoint.position.z).normalized * 15);
        }
    }
}
