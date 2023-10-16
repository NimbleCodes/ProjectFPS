using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] GameObject _player, _cam;
    private static EventManager eventManager = null;
    bool _isSpawnDone = false, _isStageStarted = false, _isGameOver = false;
    bool _isGameClear = false;
    int AllEnemy, EnemyKilled = 0;

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


    void Update()
    {
        if(_isStageStarted == false){
            Invoke_StageStartEvent();
            _isStageStarted = true;
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

    public GameObject GetMainCamera(){
        if(_cam == null){
            _cam = GameObject.FindGameObjectWithTag("MainCamera");
        }
        return _cam;
    }
    public void SetGameClear(bool tf){
        _isGameClear = tf;
    }

    public void SetGameOver(bool tf){
        _isGameOver = tf;
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

    // 스테이지 시작시 모든 데이터 init
    // 모든 스포너 init
    public event Action StageStartEvent;
    public void Invoke_StageStartEvent(){
        if(StageStartEvent != null){
            StageStartEvent();
        }
    }

    // 스테이지 종료시 모든 데이터 초기화
    // 모든 스포너 초기화
    // 이미 나와있는 몬스터 초기화
    // respawn point로 캐릭터 옮김
    public event Action GameOverEvent;
    public void Invoke_GmaeOverEvent(){
        if(GameOverEvent != null){
            GameOverEvent();
        }
    }
    
    // 모든 이펙트 볼륨 변경 함수를 등록
    // 이펙트 value 변경시 event 실행, 모든 이팩트 볼륨 관리
    public event Action<float> EffectsVolumeChangeEvent;
    public void Invoke_EffectsVolumeChangeEvent(float volume){
        if(EffectsVolumeChangeEvent != null){
            EffectsVolumeChangeEvent(volume);
        }
    }
    public event Action BossTriggerEvent;
    public void Invoke_BossTriggerEvent(){
        if(BossTriggerEvent != null){
            BossTriggerEvent();
        }
    }


}
