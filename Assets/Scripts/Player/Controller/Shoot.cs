using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform _shootPoint;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _aimPoint;
    [SerializeField] Transform _gunholder;
    GameObject Bullet;
    bool _isAmmoEmpty;
    void Update()
    {

        _shootPoint.LookAt(_aimPoint);
        if (Input.GetMouseButtonDown(0))
        {
            _isAmmoEmpty = gameObject.GetComponent<AmmoHolder>().AmmoStatus; 
            if(!_isAmmoEmpty){
                Bullet = Instantiate(_bulletPrefab,_shootPoint.position,_gunholder.transform.rotation);
                Bullet.GetComponent<PistolBullet>().Init(400);

                gameObject.GetComponent<AmmoHolder>().SubAmmo();
            }
        }
    }
}
