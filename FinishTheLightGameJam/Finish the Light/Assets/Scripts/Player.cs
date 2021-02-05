using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IEnemyDmgble
{
    [SerializeField] private Slider healthbar;
    [SerializeField] private Image healthbarFillImage;
    [SerializeField] private Color minHealthColour;
    [SerializeField] private Color maxHealthColour;

    public static bool IsPlayerAlive = true;
    
    [SerializeField] private int maxHealth;
    private int _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth;
        UpdateHealthbarUI();
    }

    public void TakeDamageFromEnemy(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth > 0)
        {
            IsPlayerAlive = true;
        }
        else
        {
            DeathCheck();
        }
        
        UpdateHealthbarUI();
        
    }

    void DeathCheck()
    {
        if (_currentHealth <= 0)
        {
            IsPlayerAlive = false;
            Destroy(gameObject);
        }
    }

    void UpdateHealthbarUI()
    {
        float healthPercentage = CalculateHealthPercentage();
        healthbar.value = healthPercentage;
        healthbarFillImage.color = Color.Lerp(minHealthColour, maxHealthColour, healthPercentage / 100);
    }

    float CalculateHealthPercentage()
    {
        return ((float) _currentHealth / (float) maxHealth) * 100;
    }

    
}
