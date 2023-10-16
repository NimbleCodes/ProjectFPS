using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("Main");
        }
    }
}
