using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    [SerializeField] private Slider HealthBar;
    public float currentHealth;
    public static HealthManager instance;
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

    public void SetHealth(float healthAmount){
        HealthBar.maxValue = healthAmount;
        HealthBar.value = healthAmount;
        currentHealth = HealthBar.value;
    }

    void UpdateHealth(){
        HealthBar.value = currentHealth;
    }
}
