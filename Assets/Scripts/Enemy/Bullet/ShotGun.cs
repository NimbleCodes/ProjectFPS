using UnityEngine;

public class ShotGun : MonoBehaviour
{
    private void OnParticleCollision(GameObject other) {
        if(other.CompareTag("Player")){
            other.gameObject.GetComponent<HealthManager>().MinusHealth(3);
            Debug.Log("hi");
        }
    }
}
