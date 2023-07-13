using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{
    [SerializeField] GameObject _weaponRing;
    private static HudController instance;
    
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

    private void Start() {
        _weaponRing = GameObject.FindGameObjectWithTag("WeaponRing");
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
