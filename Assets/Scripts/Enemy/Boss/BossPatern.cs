using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BossPatern : MonoBehaviour
{
    [SerializeField] HealthManager _health;
    
    Transform _player;
    BossPhase _phase = new BossPhase();
    float _curHealth, _defaultHealth = 300;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _health.SetHealth(_defaultHealth);
    }

    void Update()
    {
        CheckCurHealth();
        PhaseChanger();
    }

    void CheckCurHealth(){
        _curHealth = _health.GetHealth();
    }

    void PhaseChanger(){
        if(_curHealth <= 100){
            _phase = BossPhase.Phase3;
        }else if(_curHealth <= 200){
            _phase = BossPhase.Phase2;
        }
    }

    void BossPhaseStart(){ //Phase1 production + set phase to pahse1
        // set default setting of the Boss
        // show production of phase1
    }

    void Phase1(){
        // set Phase1 weapon
        // set attack rate
        // set movement patern of the boss
        
    }

    void StartPhase2(){ //Phase2 production

    }
    void Phase2(){

    }

    void StartPhse3(){ //Phase3 production

    }
    void Phase3(){

    }
    
}

public enum BossPhase{
    Phase1,
    Phase2,
    Phase3,
}