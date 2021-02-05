using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] TestSubject001;
    public int spawnTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Spawn()
    {
        Instantiate(TestSubject001[1]);
    }
}
