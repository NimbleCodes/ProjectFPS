using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager eventManager = null;

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
