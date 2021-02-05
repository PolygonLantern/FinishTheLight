using System;
using System.Collections;
using UnityEngine;

public class EnemyDamage : Enemy
{
    private void OnTriggerEnter(Collider other)
    {
        IEnemyDmgble enemyDmgble = other.GetComponent<IEnemyDmgble>();

        if (enemyDmgble != null)
        {
            StartCoroutine(Attack(enemyDmgble, enemyStats.attackRate));
        }

    }

    IEnumerator Attack(IEnemyDmgble enemyDmgble, float attackDelay)
    {
        while (Player.IsPlayerAlive)
        {
            if (enemyDmgble != null)
            {
                enemyDmgble.TakeDamageFromEnemy(enemyStats.damage);
            }
            yield return new WaitForSeconds(attackDelay);
        }
        
    }
}
