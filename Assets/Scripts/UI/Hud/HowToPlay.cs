using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    GameObject _hud;
    private void Awake() {
        PlayerPrefs.SetInt("HowToPlayOpen", 0);
    }
    private void Start() {
        _hud = EventManager.events.GetHud();
    }
    public void OnExitClick(){
        gameObject.SetActive(false);
        if(PlayerPrefs.GetInt("HowToPlayOpen") != 1){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _hud.GetComponent<HudController>().SetMainMenuFlag(false);
            PlayerPrefs.SetInt("HowToPlayOpen", 1);
        }
        
    }


}
