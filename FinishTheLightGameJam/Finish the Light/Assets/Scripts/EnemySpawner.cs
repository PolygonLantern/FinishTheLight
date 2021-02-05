using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public enum Level { Easy, SlightlyDifficult, Medium, Hard, YouAreGood, Suicidal, HellInTheOffice}
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject[] spawnPositions;
    private int _enemiesPerLevel;
    public static int EnemiesRemaining;

    private void Start()
    {
        StartCoroutine(nameof(SpawnEnemies));
    }
    
    private void OnDisable()
    {
        StopCoroutine(nameof(SpawnEnemies));
    }

    Level CheckLevel()
    {
        Level level = Level.Easy;

        if (ScoreManager.Score >= 200)
            level = Level.Easy;
        
        if (ScoreManager.Score >= 400)
            level = Level.SlightlyDifficult;
        
        if (ScoreManager.Score >= 600)
            level = Level.Medium;
        
        if (ScoreManager.Score >= 800)
            level = Level.Hard;

        if (ScoreManager.Score >= 1600)
            level = Level.YouAreGood;

        if (ScoreManager.Score >= 3200)
            level = Level.Suicidal;

        if (ScoreManager.Score >= 6400)
        {
            level = Level.HellInTheOffice;
        }
            

        
        return level;
    }

    void UpdateLevel()
    {
        switch (CheckLevel())
        {
            case Level.Easy:
                _enemiesPerLevel = 3;
                break;
            case Level.SlightlyDifficult:
                _enemiesPerLevel = 5;
                break;
            case Level.Medium:
                _enemiesPerLevel = 8;
                break;
            case Level.Hard:
                _enemiesPerLevel = 13;
                break;
            case Level.YouAreGood:
                _enemiesPerLevel = 21;
                break;
            case Level.Suicidal:
                _enemiesPerLevel = 34;
                break;
            case Level.HellInTheOffice:
                _enemiesPerLevel = 55;
                break;
                
        }
    }
    
    void SpawnEnemy()
    {
        UpdateLevel();
        
        for (int i = 0; i < _enemiesPerLevel; i++)
        {
            Instantiate(enemyPrefab, spawnPositions[Random.Range(0, spawnPositions.Length)].transform);
            EnemiesRemaining++;
        }

        UIManager.Instance.enemiesRemainingText.text = EnemiesRemaining.ToString();
    }

    IEnumerator SpawnEnemies()
    {
        while (Player.IsPlayerAlive)
        {
            SpawnEnemy();
            yield return new WaitUntil(() => EnemiesRemaining <= 0);
        }
    }
}
