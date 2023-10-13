using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AreYouSure : MonoBehaviour
{
    [SerializeField] Text _caution;
    bool _isRestart = false, _isMain = false, _isQuit = false;

    void Update()
    {
        if(_isRestart){
            _caution.text = "Are you sure to Restart?";
        }else if(_isMain){
            _caution.text = "Return to Main?";
        }else if(_isQuit){
            _caution.text = "Are you sure to Quit?";
        }
    }

    public void SetRestart(bool val){
        _isRestart = val;
    }

    public void SetMain(bool val){
        _isMain = val;
    }

    public void SetQuit(bool val){
        _isQuit = val;
    }

    //flag 초기화 후 동작수행
    public void OkButtonOnClick(){
        if(_isRestart){
            _isRestart = false;
            SceneManager.LoadScene("AlphaScene");
        }else if(_isMain){
            _isMain = false;
            SceneManager.LoadScene("Main");
        }else if(_isQuit){
            _isQuit = false;
            Application.Quit();
        }
    }

    //flag 초기화 후 패널 닫음
    public void CancelButtonOnClick(){
        if(_isRestart){
            _isRestart = false;
        }else if(_isMain){
            _isMain = false;
        }else if(_isQuit){
            _isQuit = false;
        }

        gameObject.SetActive(false);
    }
}
