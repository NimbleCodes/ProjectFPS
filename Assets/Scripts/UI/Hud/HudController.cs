using UnityEngine;

public class HudController : MonoBehaviour
{
    [SerializeField] GameObject[] _allWeapon;
    [SerializeField] GameObject _weaponRing;
    [SerializeField] GameObject _mainMenu;
    [SerializeField] GameObject _camController;
    [SerializeField] GameObject _YouDiedPanel;
    [SerializeField] GameObject _GameClearPanel;
    [SerializeField] bool _isRingActive = false, _isMainMenuActive =false;
    GameObject _currentWeapon;
    
    

    private void Start() {
        _weaponRing.SetActive(false);
        _mainMenu.SetActive(false);
        _YouDiedPanel.SetActive(false);
        _GameClearPanel.SetActive(false);
        _currentWeapon = GameObject.Find("Pistol");
        _camController = EventManager.events.GetMainCamera();
        EventManager.events.GameOverEvent += ShowYouDiedPanel;
        EventManager.events.GameClearEvent += ShowGameClearPanel;
    }

    void Update()
    {
        //RingMenu
        if(Input.GetKeyDown(KeyCode.Tab) && !_isMainMenuActive){
            if(!_isRingActive){
                showWeaponRing();
                for(int i =0; i < _allWeapon.Length; i++){
                    _allWeapon[i].GetComponent<Shoot>().enabled = false;
                }
            }else{
                closeWeaponRing();
                for(int i =0; i < _allWeapon.Length; i++){
                    _allWeapon[i].GetComponent<Shoot>().enabled = true;
                }
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
    public void SetMainMenuFlag(bool tf){
        _isMainMenuActive = tf;
    }
    void SetCurrentWeapon(GameObject weapon){
        _currentWeapon = weapon;
    }

    public void SlowDownScene(){
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void PauseScene(){
        Time.timeScale = 0f;
    }

    public void SceneNormalSpeed(){
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    void showWeaponRing(){
        _weaponRing.SetActive(true);
        _isRingActive = true;
        // 캐릭터 입력 비활성화
        //_camController.GetComponent<CameraFlow>().enabled = false;
        _currentWeapon.GetComponent<Shoot>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void closeWeaponRing(){
        _weaponRing.SetActive(false);
        _isRingActive = false;
        // 캐릭터 입력 활성화
        //_camController.GetComponent<CameraFlow>().enabled = true;
        _currentWeapon.GetComponent<Shoot>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ShowMainMenu(){
        _mainMenu.SetActive(true);
        _isMainMenuActive = true;
        // 캐릭터 입력 비활성화
        _camController.GetComponent<CameraFlow>().enabled = false;
        _currentWeapon.GetComponent<Shoot>().enabled = false;
        // 마우스 커서 활성화
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void CloseMainMenu(){
        _mainMenu.SetActive(false);
        _isMainMenuActive = false;
        // 캐릭터 입력 활성화
        _camController.GetComponent<CameraFlow>().enabled = true;
        _currentWeapon.GetComponent<Shoot>().enabled = true;
        // 마우스 커서 비활성화
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowYouDiedPanel(){
        _YouDiedPanel.SetActive(true);
        _camController.GetComponent<CameraFlow>().enabled = false;
        _currentWeapon.GetComponent<Shoot>().enabled = false;
    }

    public void ShowGameClearPanel(){
        _GameClearPanel.SetActive(true);
        _camController.GetComponent<CameraFlow>().enabled = false;
        _currentWeapon.GetComponent<Shoot>().enabled = false;
    }
}
