using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistakesDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>()!= null)
        {
            EnemySpawner.EnemiesRemaining--;
        }
        Destroy(other.gameObject);
    }
}
