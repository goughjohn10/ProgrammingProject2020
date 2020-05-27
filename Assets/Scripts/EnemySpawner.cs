using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    private Vector3 spawnPointOne;
    
    public static float enemyCount = 10;
    
    private float[] spawnLocsZ = new float[] {1.5f, 7.5f};

    public GameObject arch;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(arch, new Vector3(4.5f, 0, spawnLocsZ[0]), Quaternion.identity);
        Instantiate(arch, new Vector3(4.5f, 0, spawnLocsZ[1]), Quaternion.identity);
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
            spawnPointOne = new Vector3(Random.Range(3,6),0.5f, spawnLocsZ[Random.Range(0,2)]);
            SpawnEnemies(spawnPointOne);
        }
        
        
    }

    void SpawnEnemies(Vector3 location)
    {
        enemyCount += 1;
        Instantiate(enemy, location, Quaternion.identity);
    }
}
