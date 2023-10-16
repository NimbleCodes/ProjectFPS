using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("AlphaScene");
        }
    }
}
