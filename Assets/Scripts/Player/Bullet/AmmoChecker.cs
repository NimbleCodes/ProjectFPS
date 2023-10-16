using UnityEngine;
using UnityEngine.UI;

public class AmmoChecker : MonoBehaviour
{
    [SerializeField] Text[] _ammoInfo;
    [SerializeField] GameObject _weaponRing;
    [SerializeField] Sprite[] _weaponImgs;
    [SerializeField] Image _currentWeaponImg;
    [SerializeField] Text _currentAmmoText;

    //Pistol Ammo Info Guns[0]
    int curPAmmo = 12, maxPAmmo = 60;
    public bool _isPistolEmpty { get; set;}

    // Assult Rifle Ammo Info Guns[1]
    int curAAmmo = 60, maxAAmmo = 240;
    public bool _isAssultREmpty {get; set;}

    // Plasma Cannon Ammo Info Guns[2]
    int curCAmmo = 10, maxCAmmo = 30;
    public bool _isCannonEmpty {get; set;}

    // Blaster Ammo Info Guns[3]
    int curBAmmo = 12, maxBAmmo = 24;
    public bool _isBlasterEmpty {get;set;}

    // Current Weapon info
    int currentWeapon;
    private void Awake() {
        _weaponRing = GameObject.Find("WeaponRing");
    }
    void Update()
    {
        UpdateAmmoInfo();
    }

    void Start()
    {
        _ammoInfo = _weaponRing.GetComponent<SlotController>().GetTexts();
        SetCurrentWeapon(0);
        
    }

    public void SetCurrentWeapon(int num){
        currentWeapon= num;
        switch(currentWeapon){
            case 0:
                _currentWeaponImg.sprite = _weaponImgs[0];
                _currentAmmoText.text = $"{curPAmmo}/{maxPAmmo}";
                break;

            case 1:
                _currentWeaponImg.sprite = _weaponImgs[1];
                _currentAmmoText.text = $"{curAAmmo}/{maxAAmmo}";
                break;

            case 2:
                _currentWeaponImg.sprite = _weaponImgs[2];
                _currentAmmoText.text = $"{curCAmmo}/{maxCAmmo}";
                break;
            
            case 3:
                _currentWeaponImg.sprite = _weaponImgs[4];
                _currentAmmoText.text = $"{curBAmmo}/{maxBAmmo}";
                break;
        }
    }
    public void AddPistolAmmo(int ammo){
        curPAmmo += ammo;
        if(curPAmmo >= maxPAmmo){
            curPAmmo = maxPAmmo;
        }
    }
    public void SubPistolAmmo(){
        curPAmmo -= 1;
        if(curPAmmo < 0){
            curPAmmo =0;
        }
    }

    public void AddAssultRAmmo(int ammo){
        curAAmmo += ammo;
        if(curAAmmo >= maxAAmmo){
            curAAmmo = maxAAmmo;
        }
    }
    public void SubAssultRAmmo(){
        curAAmmo -= 1;
        if(curAAmmo < 0){
            curAAmmo = 0;
        }
    }

    public void AddPlasmaCAmmo(int ammo){
        curCAmmo += ammo;
        if(curCAmmo >= maxCAmmo){
            curCAmmo = maxCAmmo;
        }
    }
    public void SubPlasmaCAmmo(){
        curCAmmo -= 1;
        if(curCAmmo < 0){
            curCAmmo = 0;
        }
    }

    public void AddBlasterAmmo(int ammo){
        curBAmmo += ammo;
        if(curBAmmo >= maxBAmmo){
            curBAmmo = maxBAmmo;
        }
    }
    public void SubBlasterAmmo(){
        curBAmmo -= 1;
        if(curBAmmo < 0){
            curBAmmo = 0;
        }
    }

    public void UpdateAmmoInfo(){
        _ammoInfo[0].text = $"{curPAmmo}/{maxPAmmo}";
        _ammoInfo[1].text = $"{curAAmmo}/{maxAAmmo}";
        _ammoInfo[2].text = $"{curCAmmo}/{maxCAmmo}";
        _ammoInfo[3].text = $"{curBAmmo}/{maxBAmmo}";

        if(curPAmmo <= 0){
            _isPistolEmpty = true;
        }else{
            _isPistolEmpty = false;
        }

        if(curAAmmo <= 0){
            _isAssultREmpty = true;
        }else{
            _isAssultREmpty = false;
        }

        if(curCAmmo <= 0){
            _isCannonEmpty = true;
        }else{
            _isCannonEmpty = false;
        }

        if(curBAmmo <= 0){
            _isBlasterEmpty = true;
        }else{
            _isBlasterEmpty = false;
        }

        switch(currentWeapon){
            case 0:
                _currentAmmoText.text = $"{curPAmmo}/{maxPAmmo}";
                break;

            case 1:
                _currentAmmoText.text = $"{curAAmmo}/{maxAAmmo}";
                break;

            case 2:
                _currentAmmoText.text = $"{curCAmmo}/{maxCAmmo}";
                break;
            
            case 3:
                _currentAmmoText.text = $"{curBAmmo}/{maxBAmmo}";
                break;
        }
    }

    
}
