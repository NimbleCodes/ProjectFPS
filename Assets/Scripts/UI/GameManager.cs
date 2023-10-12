using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    bool _isSpawnDone = false, _isStageStarted = false;
    
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

    void Update()
    {
        if(_isStageStarted == false){
            EventManager.events.Invoke_StageStartEvent();
            _isStageStarted = true;
        }
    }
    public void SpawnCheck(bool done){
        _isSpawnDone = done;
    }
    
}
