using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _spawnPoint;
    [SerializeField] GameObject[] _ammo;

    void Start()
    {
        SpawnAmmo();
    }

    public void SpawnAmmo(){
        for(int i =0; i < _spawnPoint.Length; i++){
            int rand = Random.Range(0,_ammo.Length);
            Instantiate(_ammo[rand], _spawnPoint[i].transform);
        }
    }
}
