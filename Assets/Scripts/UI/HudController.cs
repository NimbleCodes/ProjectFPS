using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{
    private static HudController instance;
    GameObject _weaponRing = null;
    public GameObject weponRing{get {return _weaponRing;}}
    void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
        
    }

    public static HudController Instance{
        get{return instance;}

    }

    private void FixedUpdate() {
        if(_weaponRing == null){
            _weaponRing = GameObject.FindGameObjectWithTag("WeaponRing");
        }
    }
}
