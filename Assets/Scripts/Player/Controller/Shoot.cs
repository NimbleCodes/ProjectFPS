using UnityEngine;


public class Shoot : MonoBehaviour
{
    [SerializeField] Transform _shootPoint;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _aimPoint;
    [SerializeField] Transform _gunholder;
    [SerializeField] GunType _gunType;
    GameObject Bullet;
    public bool _isAmmoEmpty;
    GameObject _ammoChecker;

    void Awake()
    {
        _ammoChecker = GameObject.Find("AmmoChecker");
    }

    void Update()
    {
        if(_gunType == GunType.Pistol){
            _isAmmoEmpty = _ammoChecker.GetComponent<AmmoChecker>()._isPistolEmpty;
        }else if(_gunType == GunType.AssultRifle){
            _isAmmoEmpty = _ammoChecker.GetComponent<AmmoChecker>()._isAssultREmpty;
        }  
        
        _shootPoint.LookAt(_aimPoint);
        if (Input.GetMouseButtonDown(0))
        { 
            if(_isAmmoEmpty == false){
                Bullet = Instantiate(_bulletPrefab,_shootPoint.position,_gunholder.transform.rotation);
                Bullet.GetComponent<PistolBullet>().Init(400);

                if(_gunType == GunType.Pistol){
                    _ammoChecker.GetComponent<AmmoChecker>().SubPistolAmmo();
                }else if(_gunType == GunType.AssultRifle){
                    _ammoChecker.GetComponent<AmmoChecker>().SubAssultRAmmo();
                }
                
            }
        }
    }
}

public enum GunType{
    Pistol,
    AssultRifle,
    PlasmaCannon,
    Blaster,
}
