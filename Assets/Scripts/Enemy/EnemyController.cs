using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform _shootPoint;
    [SerializeField] Transform _player;
    [SerializeField] LayerMask _LGround, _LPlayer;
    [SerializeField] GameObject _enemyBullet;
    //patrol
    [SerializeField] Vector3 _patrolPoint;
    NavMeshAgent _nav;
    float _patrolRange = 5f;
    bool _isPointSet;

    //Attack
    float _attackDelay = 0.5f;
    bool _isAttacked;

    //Enemy State
    float _sightRange = 20f, _attackRange= 12f;
    bool _isInSight, _isInAttackRange,_isDead = false;
    public bool IsDead {get{return _isDead;} set{_isDead = value;}}
    Rigidbody _rig;
    float _dealtDamage =0;
    
    
    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
        _nav = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() {
        if(_isDead) Destroy(gameObject);
        _isInSight = Physics.CheckSphere(transform.position, _sightRange, _LPlayer);
        _isInAttackRange = Physics.CheckSphere(transform.position, _attackRange,_LPlayer);

        if(_isInSight == false && _isInAttackRange==false) Patrol();
        if(_isInSight && _isInAttackRange == false) Chase();
        if(_isInSight && _isInAttackRange) Attack();
    }
    void Patrol(){
        if(_isPointSet == false) SearchPatrolPoint();

        if(_isPointSet) _nav.SetDestination(_patrolPoint);

        Vector3 patrolPointDistance = transform.position - _patrolPoint;

        if(patrolPointDistance.magnitude < 1f){
            _isPointSet = false;
        }
    }

    void SearchPatrolPoint(){
        float randXPoint = Random.Range(-_patrolRange, _patrolRange);
        float randZPoint = Random.Range(-_patrolRange, _patrolRange);

        _patrolPoint = new Vector3(transform.position.x + randXPoint, transform.position.y, transform.position.z + randZPoint);

        if(Physics.Raycast(_patrolPoint, -transform.up,2f, _LGround)){
            _isPointSet = true;
        }
    }

    void Chase(){
        _nav.SetDestination(_player.position);
    }

    void Attack(){
        _nav.SetDestination(transform.position);
        transform.LookAt(_player);
        _shootPoint.LookAt(_player);

        if(_isAttacked == false){
            GameObject bullet = Instantiate(_enemyBullet, _shootPoint.transform.position,transform.rotation);
            bullet.GetComponent<Bomb>().Init(150);
            _isAttacked =true;
            Invoke(nameof(ResetAttack), _attackDelay);
        }
    }

    void ResetAttack(){
        _isAttacked = false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _sightRange);
    }

}
