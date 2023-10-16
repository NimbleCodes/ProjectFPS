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
        _aimPoint = GameObject.Find("AimPoint").transform;
        _gunholder = GameObject.Find("GunHolder").transform;
    }

    void Update()
    {
        if(_gunType == GunType.Pistol){
            _isAmmoEmpty = _ammoChecker.GetComponent<AmmoChecker>()._isPistolEmpty;
        }else if(_gunType == GunType.AssultRifle){
            _isAmmoEmpty = _ammoChecker.GetComponent<AmmoChecker>()._isAssultREmpty;
        }  
        
        _shootPoint.LookAt(_aimPoint);

        // Todo : 총기 형식에 따른 발사 Force 설정
        // 발사후 총알에서 자체적인 Force 적용이 아닌
        // 총기로부터 Force를 주는것으로 변경필요
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
        }
    }
}

public enum GunType{
    Pistol,
    AssultRifle,
    PlasmaCannon,
    Blaster,
}
