using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    bool _isSpawnDone = false;
    
    void Awake()
    {
        if(instance == null){
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }else{
            Destroy(this.gameObject);
        }
    }
    public static GameManager Instance{//singleton
        get{
            if(instance == null){
                return null;
            }

            return instance;
        }
    }
    public void SpawnCheck(bool done){
        _isSpawnDone = done;
    }
}
