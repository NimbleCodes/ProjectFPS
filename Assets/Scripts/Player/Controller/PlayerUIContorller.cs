using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIContorller : GenericSingleton<PlayerUIContorller>
{
    GameObject _weaponRing = null, _camController = null;
    bool _isRingActive = false;
    float slowLength =4;
    void FixedUpdate(){
        if(_weaponRing == null && _camController == null){
            _weaponRing = HudController.Instance.weponRing;
            _camController = GenericSingleton<CameraFlow>.Instance.gameObject;
            _weaponRing.SetActive(false);
            _isRingActive = false;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(!_isRingActive){
                _weaponRing.SetActive(true);
                _isRingActive = true;
                _camController.GetComponent<CameraFlow>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
            }else if(_isRingActive){
                _weaponRing.SetActive(false);
                _isRingActive = false;
                _camController.GetComponent<CameraFlow>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if(_isRingActive)SlowDownScene();
        if(!_isRingActive)SceneNormalSpeed();
    }

    void SlowDownScene(){
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    void SceneNormalSpeed(){
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}