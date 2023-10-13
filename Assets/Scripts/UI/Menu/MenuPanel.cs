using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] GameObject _optionPanel;
    [SerializeField] GameObject _helpPanel;
    [SerializeField] GameObject _areYouSurePanel;

    void Start()
    {
        _optionPanel.SetActive(false);
        _helpPanel.SetActive(false);
        _areYouSurePanel.SetActive(false);
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
        _areYouSurePanel.SetActive(false);
        _areYouSurePanel.GetComponent<AreYouSure>().SetMain(true);
    }

    public void OnQuitClick(){
        _areYouSurePanel.SetActive(false);
        _areYouSurePanel.GetComponent<AreYouSure>().SetQuit(true);
    }
}
