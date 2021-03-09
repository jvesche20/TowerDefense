using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;



    public float timeWaves = 5f;
    private float countDown = 2f;

    private int waveNumber = 1;

    void Update()
    {
        if(countDown <= 0)
        {
            SpawnWave();
            countDown = timeWaves;
        }
        // removes countDown once every second
        countDown -= Time.deltaTime;
    }

    void SpawnWave()
    {

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
        }
        waveNumber++;

    }
    //numOfEnemies = waveNumber* waveNumber + 1;

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
