using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Gun : ScriptableObject
{
    public string gunName;
    public GameObject gunPrefab;
    
    public int maxDamage;
    public int minDamage;
    public float maxRange;
    

}
