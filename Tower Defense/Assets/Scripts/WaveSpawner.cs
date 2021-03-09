using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;



    public float timeWaves = 5f;
    private float countDown = 2f;

    private int waveNumber = 0;

    public Text waveCountdownTxt;

    void Update()
    {
        if(countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeWaves;
        }
        // removes countDown once every second
        countDown -= Time.deltaTime;

        waveCountdownTxt.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {

            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        

    }
    //numOfEnemies = waveNumber* waveNumber + 1;

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
