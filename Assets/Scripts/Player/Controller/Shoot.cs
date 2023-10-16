using UnityEngine;


public class Shoot : MonoBehaviour
{
    [SerializeField] Transform _shootPoint;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _aimPoint;
    [SerializeField] Transform _gunholder;
    [SerializeField] GunType _gunType;
    [SerializeField] AudioClip _effect;
    [SerializeField] AudioSource _effectPlayer;
    GameObject Bullet;
    public bool _isAmmoEmpty;
    GameObject _ammoChecker;

    void Awake()
    {
        _ammoChecker = GameObject.Find("AmmoChecker");
        _aimPoint = GameObject.Find("AimPoint").transform;
        _gunholder = GameObject.Find("GunHolder").transform;
    }

    void Update()
    {
        if(_gunType == GunType.Pistol){
            _isAmmoEmpty = _ammoChecker.GetComponent<AmmoChecker>()._isPistolEmpty;
        }else if(_gunType == GunType.AssultRifle){
            _isAmmoEmpty = _ammoChecker.GetComponent<AmmoChecker>()._isAssultREmpty;
        }else if(_gunType == GunType.PlasmaCannon){
            _isAmmoEmpty = _ammoChecker.GetComponent<AmmoChecker>()._isCannonEmpty;
        }else if(_gunType == GunType.Blaster){
            _isAmmoEmpty = _ammoChecker.GetComponent<AmmoChecker>()._isBlasterEmpty;
        }
        
        _shootPoint.LookAt(_aimPoint);

        if (Input.GetMouseButtonDown(0))
        { 
            if(_isAmmoEmpty == false){
                Bullet = Instantiate(_bulletPrefab,_shootPoint.position,_gunholder.transform.rotation);
                
                if(_gunType == GunType.Pistol){
                    _ammoChecker.GetComponent<AmmoChecker>().SubPistolAmmo();
                    Bullet.GetComponent<PistolBullet>().Init(400);
                }else if(_gunType == GunType.AssultRifle){
                    _ammoChecker.GetComponent<AmmoChecker>().SubAssultRAmmo();
                    Bullet.GetComponent<PistolBullet>().Init(400);
                }else if(_gunType == GunType.PlasmaCannon){
                    _ammoChecker.GetComponent<AmmoChecker>().SubPlasmaCAmmo();
                    Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.forward * 100, ForceMode.Impulse);
                }else if(_gunType == GunType.Blaster){
                    _ammoChecker.GetComponent<AmmoChecker>().SubBlasterAmmo();
                    Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.forward * 25 + transform.up * 5,ForceMode.Impulse);
                }
                
            }

            _effectPlayer.PlayOneShot(_effect);
        }
    }
}

public enum GunType{
    Pistol,
    AssultRifle,
    PlasmaCannon,
    Blaster,
}
