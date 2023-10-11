using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] GameObject[] _enemies;

    int _spawnEnemyNumber;

    void Start()
    {
        _spawnEnemyNumber = _spawnPoints.Length;
    }

    public int GetEnemyNumber(){
        return _spawnEnemyNumber;
    }

    void SpawnEnempies(){
        for(int i =0; i < _spawnPoints.Length; i++){
            int rand = Random.Range(0,_enemies.Length-1);
            Instantiate(_enemies[rand], _spawnPoints[i]);
        }

        GameManager.Instance.SpawnCheck(true);
    }
}
