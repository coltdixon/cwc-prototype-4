using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    private float spawnRange = 9;
    private int enemyCount;
    private int powerupCount;
    private int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        powerupCount = GameObject.FindGameObjectsWithTag("PowerUp").Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            if (powerupCount == 0)
            {
                SpawnPowerUp();
            }
        }
    }

    private Vector3 GenerateSpawnPosition(float zPos)
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPosX, zPos, spawnPosZ);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(0), enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(0.3f), powerUpPrefab.transform.rotation);
    }
}
