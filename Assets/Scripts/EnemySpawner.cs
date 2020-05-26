using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    private Vector3 spawnPointOne;
    
    public static float enemyCount = 5;
    
    private float[] spawnLocs = new float[] {1.5f, 7.5f};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount <0)
        {
            enemyCount = 0;
        }
        
        if (enemyCount < 10)
        {
            spawnPointOne = new Vector3(4.5f,0.5f, spawnLocs[Random.Range(0,2)]);
            SpawnEnemies(spawnPointOne);
        }
        
        
    }

    void SpawnEnemies(Vector3 location)
    {
        Instantiate(enemy, location, Quaternion.identity);
        enemyCount += 1;
        
    }
}
