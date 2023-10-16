using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    [SerializeField] GameObject _player, _cam, _hud;
    private static EventManager eventManager = null;
    bool _isSpawnDone = false;
    bool _isGameClear = false;
    int AllEnemy, EnemyKilled = 0;
    string sceneName;

    void Awake()
    {
        if(eventManager == null){
            eventManager = this;

            DontDestroyOnLoad(this.gameObject);
        }else{
            Destroy(this.gameObject);
        }
    }

    public static EventManager events{//singleton
        get{
            if(eventManager == null){
                return null;
            }

            return eventManager;
        }
    }
    private void Start() {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if(sceneName == "AlphaScene"){
            Invoke_StageStartEvent();
        }
    }
    
    public void StopPlayerInput(){
        _player.GetComponent<Movement>().enabled =false;
        _cam.GetComponent<CameraFlow>().enabled = false;
    }

    public void StartPlayerInput(){
        _player.GetComponent<Movement>().enabled = true;
        _cam.GetComponent<CameraFlow>().enabled = true;
    }
    public GameObject GetPlayer(){
        if(_player == null){
            _player = GameObject.FindGameObjectWithTag("Player");
        }
        return _player;
    }
    public GameObject GetHud(){
        if(_hud == null){
            _hud = GameObject.Find("HUD");
        }
        return _hud;
    }

    public GameObject GetMainCamera(){
        if(_cam == null){
            _cam = GameObject.FindGameObjectWithTag("MainCamera");
        }
        return _cam;
    }
   

    public void SetEnemyNumber(int number){
        AllEnemy = number;
    }

    public void AddKilledEnemy(){
        EnemyKilled += 1;
    }

    public int GetCurrentEnemyNumb(){
        return EnemyKilled;
    }

    public int GetAllEnemyNumb(){
        return AllEnemy;
    }

    public void SpawnCheck(bool done){
        _isSpawnDone = done;
    }
    public event Action StageStartEvent;
    public event Action GameOverEvent;
    public event Action BossTriggerEvent;
    public event Action StageRestartEvent;
    public event Action GameClearEvent;
    
    public void Invoke_StageStartEvent(){
        if(StageStartEvent != null){
            StageStartEvent();
        }
    }

    public void Invoke_GameOverEvent(){
        if(GameOverEvent != null){
            GameOverEvent();
        }
    }
    
    public void Invoke_BossTriggerEvent(){
        if(BossTriggerEvent != null){
            BossTriggerEvent();
        }
    }

    public void Invoke_StageRestartEvent(){
        if(StageRestartEvent != null){
            StageRestartEvent();
        }
    }

    public void Invoke_GameClearEvent(){
        if(GameClearEvent != null){
            GameClearEvent();
        }
    }


}
