using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class AmmoChecker : MonoBehaviour
{
    [SerializeField] GameObject[] _Guns;
    [SerializeField] Text[] _ammoInfo;

    //Pistol Ammo Info Guns[0]
    int curPAmmo = 12, maxPAmmo = 60;
    public bool _isPistolEmpty { get; set;}

    // Assult Rifle Ammo Info Guns[1]
    int curAAmmo = 60, maxAAmmo = 240;
    public bool _isAssultREmpty {get; set;}

    //Plasma Cannon Ammo Info Guns[2]
    int curCAmmo = 10, maxCAmmo = 30;
    public bool _isCannonEmpty {get; set;}

    void Update()
    {
        UpdateAmmoInfo();
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

    public void UpdateAmmoInfo(){
        _ammoInfo[0].text = $"{curPAmmo}/{maxPAmmo}";
        _ammoInfo[1].text = $"{curAAmmo}/{maxAAmmo}";
        _ammoInfo[2].text = $"{curCAmmo}/{maxCAmmo}";

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
    }

    
}
