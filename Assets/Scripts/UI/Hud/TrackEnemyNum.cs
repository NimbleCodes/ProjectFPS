using UnityEngine;
using UnityEngine.UI;

public class TrackEnemyNum : MonoBehaviour
{
    [SerializeField] Text text;

    int curEnemy, MaxEnemy;
    bool _isClear = false;
    void Update()
    {
        curEnemy = EventManager.events.GetCurrentEnemyNumb();
        MaxEnemy = EventManager.events.GetAllEnemyNumb();

        text.text = $"{curEnemy} / {MaxEnemy}";

        CheckEnemyNum();
    }

    void CheckEnemyNum(){
        if(curEnemy == MaxEnemy){
            _isClear = true;
        }

        if(_isClear){
            EventManager.events.Invoke_GameClearEvent();
            _isClear =false;
        }
    }
}
