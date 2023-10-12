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

    public void OpenYouSure(){
        _areYouSurePanel.SetActive(true);
    }

    public void OnOkClick(){
        _areYouSurePanel.SetActive(false);
        //추가 사항
    }

    public void OnCancelClick(){
        _areYouSurePanel.SetActive(false);
        //추가사항
    }
}
