using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    [SerializeField] private Slider HealthBar;
    [SerializeField] float _maxHealth;
    float currentHealth;

    void Start()
    {
        EventManager.events.StageStartEvent += SetHealth;
        EventManager.events.Invoke_StageStartEvent();
    }
    private void Update()
    {
        UpdateHealth();
    }
    public void AddHealth(float health){
        currentHealth += health;
    }

    public void MinusHealth(float damage){
        currentHealth -= damage;
    }

    public void SetHealth(){
        HealthBar.maxValue = _maxHealth;
        HealthBar.value = _maxHealth;
        currentHealth = HealthBar.value;
    }

    public float GetHealth(){
        return currentHealth;
    }

    void UpdateHealth(){
        HealthBar.value = currentHealth;
        if(HealthBar.value <= 0){
            checkDeath();
        }
    }



    void checkDeath(){
        if(gameObject.CompareTag("Enemy")){
            GetComponent<EnemyController>().IsDead = true;
        }
        if(gameObject.CompareTag("Player")){

        }
    }
}
