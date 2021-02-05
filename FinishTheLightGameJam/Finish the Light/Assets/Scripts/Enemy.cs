using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamagable
{
    public EnemyStats enemyStats;
    private int _currentHealth;

    [SerializeField] private Slider healthbar;
    [SerializeField] private Image healthbarFillImage;
    [SerializeField] private Color maxHealthColour;
    [SerializeField] private Color minHealthColour;

    private void Start()
    {
        _currentHealth = enemyStats.maxHealth;
        UpdateHealthbarUI();
    }

    public void TakeDamageFromPlayer(int damage)
    {
        _currentHealth -= damage;
        DeathCheck();
        UpdateHealthbarUI();
    }

    void DeathCheck()
    {
        if (_currentHealth <= 0)
        {
            ScoreManager.Score += enemyStats.dropScore;
            EnemySpawner.EnemiesRemaining--;
            
            UIManager.Instance.scoreText.text = ScoreManager.Score.ToString();
            UIManager.Instance.enemiesRemainingText.text = EnemySpawner.EnemiesRemaining.ToString();
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
        return ((float) _currentHealth / (float) enemyStats.maxHealth) * 100;
    }

    public virtual void DealDamage(Collider other, int damage)
    {
    }

}
