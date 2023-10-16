using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] GameObject _optionPanel;
    [SerializeField] GameObject _helpPanel;
    [SerializeField] GameObject _areYouSurePanel;
    [SerializeField] GameObject _hud;

    void Start()
    {
        _optionPanel.SetActive(false);
        _helpPanel.SetActive(false);
        _areYouSurePanel.SetActive(false);
        if(PlayerPrefs.GetInt("HowToPlayOpen") != 1){
            _helpPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _hud.GetComponent<HudController>().SetMainMenuFlag(true);
        }
    }

    public void OnOptionClick(){
        _optionPanel.SetActive(true);
    }

    public void OnHelpClick(){
        _helpPanel.SetActive(true);
    }

    public void OnRestartClick(){
        _areYouSurePanel.SetActive(true);
        _areYouSurePanel.GetComponent<AreYouSure>().SetRestart(true);
    }

    public void OnMainClick(){
        _areYouSurePanel.SetActive(true);
        _areYouSurePanel.GetComponent<AreYouSure>().SetMain(true);
    }

    public void OnQuitClick(){
        PlayerPrefs.SetInt("HowToPlayOpen", 0);
        _areYouSurePanel.SetActive(true);
        _areYouSurePanel.GetComponent<AreYouSure>().SetQuit(true);
    }
}
