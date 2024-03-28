using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 9.0f;
    public int enemyCount;
    public int waveCount = 1;
    public GameObject powerUpPrefab;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemyWave(waveCount);
        spawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<enemy>().Length;

        if (enemyCount == 0) 
        {
            waveCount++;
            spawnEnemyWave(waveCount);
            spawnPowerup();
        }
    }

    void spawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++){
                    Instantiate(enemyPrefab, GenerateSpawnPosition(),
        enemyPrefab.transform.rotation);
        }
    }

    void spawnPowerup()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }


    private  UnityEngine.Vector3 GenerateSpawnPosition() 
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        UnityEngine.Vector3 randomPos = new UnityEngine.Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
