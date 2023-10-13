using UnityEngine;

public class HudController : MonoBehaviour
{
    [SerializeField] GameObject _weaponRing;
    [SerializeField] GameObject _mainMenu;
    [SerializeField] GameObject _camController;
    bool _isRingActive = false, _isMainMenuActive =false;
    
    

    private void Start() {
        _weaponRing.SetActive(false);
        _mainMenu.SetActive(false);
    }

    void Update()
    {
        //RingMenu
        if(Input.GetKeyDown(KeyCode.Tab) && !_isMainMenuActive){
            if(!_isRingActive){
                showWeaponRing();
            }else{
                closeWeaponRing();
            }
        }

        //MainMenu
        if(Input.GetKeyDown(KeyCode.Escape) && !_isRingActive){
            if(!_isMainMenuActive){
                ShowMainMenu();
            }else{
                CloseMainMenu();
            }
        }

        // SlowDown Game on RingMenu Open
        if(_isRingActive)SlowDownScene();
        if(!_isRingActive && !_isMainMenuActive)SceneNormalSpeed();

        // Pause Game on Menu Open
        if(_isMainMenuActive) PauseScene();
    }

    void SlowDownScene(){
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    void PauseScene(){
        Time.timeScale = 0f;
    }

    void SceneNormalSpeed(){
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    void showWeaponRing(){
        _weaponRing.SetActive(true);
        _isRingActive = true;
        _camController.GetComponent<CameraFlow>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void closeWeaponRing(){
        _weaponRing.SetActive(false);
        _isRingActive = false;
        _camController.GetComponent<CameraFlow>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ShowMainMenu(){
        _mainMenu.SetActive(true);
        _isMainMenuActive = true;
        _camController.GetComponent<CameraFlow>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void CloseMainMenu(){
        _mainMenu.SetActive(false);
        _isMainMenuActive = false;
        _camController.GetComponent<CameraFlow>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
