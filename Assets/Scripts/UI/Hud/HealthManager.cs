using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    [SerializeField] private Slider HealthBar;
    [SerializeField] float _maxHealth;
    float currentHealth;
    GameObject _cam;
    GameObject _player;

    void Start()
    {
        SetHealth();
        _cam = GameObject.FindGameObjectWithTag("MainCamera");
        _player = GameObject.FindGameObjectWithTag("Player");
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
            EventManager.events.AddKilledEnemy();
        }
        if(gameObject.CompareTag("Player")){
            _player.GetComponent<Movement>().enabled = false;
            _cam.GetComponent<CameraFlow>().enabled = false;
            EventManager.events.Invoke_GameOverEvent();
        }
    }
}
