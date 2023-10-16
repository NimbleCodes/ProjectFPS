using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("AlphaScene");
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }       
    }
}
