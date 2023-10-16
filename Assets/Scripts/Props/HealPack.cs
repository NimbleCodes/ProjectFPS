using UnityEngine;

public class HealPack : MonoBehaviour
{
    GameObject _player;
    private void Start() {
        _player = EventManager.events.GetPlayer();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            _player.GetComponent<HealthManager>().AddHealth(50);
            Destroy(gameObject);
        }
    }
}
