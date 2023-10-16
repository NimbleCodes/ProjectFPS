using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] GameObject[] _enemies;
    [SerializeField] GameObject[] _enemiesOnField;

    int _spawnEnemyNumber;

    void Start()
    {
        _spawnEnemyNumber = _spawnPoints.Length;
        EventManager.events.SetEnemyNumber(_spawnEnemyNumber);
        SpawnEnemies();
        EventManager.events.GameOverEvent += DeleteAllEnemyFromScene;
    }

    void SpawnEnemies(){
        GameObject temp;
        for(int i =0; i < _spawnPoints.Length; i++){
            int rand = Random.Range(0,_enemies.Length);
            temp = Instantiate(_enemies[rand], _spawnPoints[i]);
            
        }
        
        EventManager.events.SpawnCheck(true);
    }

    public void DeleteAllEnemyFromScene(){
        _enemiesOnField = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i =0; i < _enemiesOnField.Length; i++){
            _enemiesOnField[i].SetActive(false);
        }
    }
}
