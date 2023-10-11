using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager instance = null;

    void Awake()
    {
        if(instance == null){
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }else{
            Destroy(this.gameObject);
        }
    }

    public static EventManager Instance{//singleton
        get{
            if(instance = null){
                return null;
            }

            return instance;
        }
    }


    // 스테이지 시작시 모든 데이터 init
    // 모든 스포너 init
    public event Action StageStartEvent;

    // 스테이지 종료시 모든 데이터 초기화
    // 모든 스포너 초기화
    // 이미 나와있는 몬스터 초기화
    // respawn point로 캐릭터 옮김
    public event Action GameOverEvent;
    
    // 모든 이펙트 볼륨 변경 함수를 등록
    // 이펙트 value 변경시 event 실행, 모든 이팩트 볼륨 관리
    public event Action<float> EffectsVolumeChangeEvent;
    public event Action BossTriggerEvent;


}
