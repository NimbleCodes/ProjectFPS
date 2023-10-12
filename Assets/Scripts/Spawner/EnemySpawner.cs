using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] GameObject[] _enemies;

    int _spawnEnemyNumber;

    void Start()
    {
        _spawnEnemyNumber = _spawnPoints.Length;
        EventManager.events.StageStartEvent += SpawnEnemies;
    }

    public int GetEnemyNumber(){
        return _spawnEnemyNumber;
    }

    void SpawnEnemies(){
        GameObject temp;
        for(int i =0; i < _spawnPoints.Length; i++){
            int rand = Random.Range(0,_enemies.Length);
            temp = Instantiate(_enemies[rand], _spawnPoints[i]);
            
        }

        GameManager.Instance.SpawnCheck(true);
    }
}
