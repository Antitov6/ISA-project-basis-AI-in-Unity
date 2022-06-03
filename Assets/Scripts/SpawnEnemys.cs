using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{

    [SerializeField] int minTimeBetweenSpawn;
    [SerializeField] int maxTimeBetweenSpawn;
    float currentTime;
    int randomTimeBetweenSpawn;
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 enemySpawnPosition;


    void Start()
    {
        currentTime = 0;
        randomTimeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
    }


    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= randomTimeBetweenSpawn)
        {
            Instantiate(enemy, enemySpawnPosition, Quaternion.identity);
            randomTimeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
            currentTime = 0;
        }
    }
}
