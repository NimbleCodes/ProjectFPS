using UnityEngine;

public class BossPatern : MonoBehaviour
{
    [SerializeField] HealthManager _health;
    [SerializeField] GameObject[] weapons;
    Transform _player;
    BossPhase _phase = new BossPhase();
    float _curHealth, _defaultHealth = 300, _attackRate=0f;
    bool _phase1Started=false, _phase2Started=false, _phase3Started=false;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        // set weapons active to false
        for(int i =0; i < weapons.Length; i++){
            weapons[i].SetActive(false);
        }

    }

    void Update()
    {
        CheckCurHealth();
        PhaseChanger();
        CheckPhase();

        if(_phase1Started) Phase1();
        if(_phase2Started) Phase1();
        if(_phase3Started) Phase1();

    }

    void CheckCurHealth(){
        _curHealth = _health.GetHealth();
    }

    void PhaseChanger(){
        if(_curHealth <= 100){
            _phase = BossPhase.Phase3;
        }else if(_curHealth <= 200){
            _phase = BossPhase.Phase2;
        }else if(_curHealth <= 300){
            _phase = BossPhase.Phase1;
        }
    }

    void CheckPhase(){
        if(_phase == BossPhase.Phase1){
            StartPhase1();
        }else if(_phase == BossPhase.Phase2){
            StartPhase2();
        }else if(_phase == BossPhase.Phase3){
            StartPhase3();
        }
    }

    void StartPhase1(){
        // set default setting of the Boss
        // set Phase1 weapon
        ChangeWeapon(0);
        _attackRate = 2f;


        //set flag to ture
        _phase1Started = true;

    }

    void Phase1(){
        // set movement patern of the boss
        gameObject.transform.LookAt(_player);

        
    }

    void StartPhase2(){
        //set _phase1 flag to false, stop phase1 
        _phase1Started = false;
        ChangeWeapon(1);
        _attackRate = 2.3f;

        //set flag to true
        _phase2Started = false;
    }
    void Phase2(){

    }

    void StartPhase3(){

    }
    void Phase3(){

    }

    void Dash(){

    }

    void ChangeWeapon(int weaponNum){
        for(int i =0; i < weapons.Length; i++){
            weapons[i].SetActive(false);
        }

        weapons[weaponNum].SetActive(true);
    }
    
}

public enum BossPhase{
    Phase1,
    Phase2,
    Phase3,
}