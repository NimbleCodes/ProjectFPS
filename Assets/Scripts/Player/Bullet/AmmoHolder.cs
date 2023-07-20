using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoHolder : MonoBehaviour
{
    [SerializeField] Text _ammoInfo;
    [SerializeField] int _curAmmo;
    [SerializeField] int _maxAmmo;
    bool _isAmmoEmpty = false;
    public bool AmmoStatus {get{return _isAmmoEmpty;}}
    void Update()
    {
        checkMinMaxEmpty();
        _ammoInfo.text = $"{_curAmmo} / {_maxAmmo}";
    }

    public void AddAmmo(int ammoPack){
        _curAmmo += ammoPack;
    }

    public void SubAmmo(){
        _curAmmo -= 1;
    }

    void checkMinMaxEmpty(){
        if(_curAmmo < 0){
            _curAmmo = 0;
            _isAmmoEmpty = true;
        }
        if(_curAmmo > 0){
            _isAmmoEmpty = false;
        }
        if(_curAmmo > _maxAmmo){
            _curAmmo = _maxAmmo;
        }
    }
}
