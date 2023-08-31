using UnityEngine;


public class AmmoHolder : MonoBehaviour
{
    [SerializeField] int _curAmmo;
    [SerializeField] int _maxAmmo;
    bool _isAmmoEmpty = false;
    public bool AmmoStatus {get{return _isAmmoEmpty;}}

    
    void Update()
    {
        checkMinMaxEmpty();
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
