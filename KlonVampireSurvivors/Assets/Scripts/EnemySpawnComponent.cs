using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnComponent : MonoBehaviour
{
    [Serializable]
    public class SpawnWave
    {
        public List<EnemySpawn> enemyList = new List<EnemySpawn>();
        public int totalToSpawn;
        public int totalSpawned;
    }

    [Serializable]
    public class EnemySpawn
    {
        public GameObject enemyPrefab;
        public int toSpawn;
        public int spawned;
    }

    public List<SpawnWave> waves;
    public List<Transform> spawnPoints;
    private int currentWave;
    private bool canSpawn = true;
    private bool addWave;
    private float spawnInterval = 1f;
    private float waveInterval = 30f;
    public GameState gameState;

    private void Start()
    {
        TotalToSpawn();
        StartCoroutine(WaveInterval());
    }

    void Update()
    {
        if(addWave)
        {
            AddWave();
        }
        if(canSpawn)
        {
            SpawnEnemies();
            TotalToSpawn();
        }
    }

    public void AddWave()
    {
        // Increment current wave
        currentWave++;
        // Check if it is last wave and stop spawning
        if (currentWave == waves.Count)
        {
            canSpawn = false;
            gameState.Victory();
            return;
        }
        else
        {
            // Start countdown for next wave
            StartCoroutine(WaveInterval());
        }
    }

    public void TotalToSpawn()
    {
        int spawnCount = 0;
        foreach(EnemySpawn spawn in waves[currentWave].enemyList)
        {
            spawnCount += spawn.toSpawn;
        }
        waves[currentWave].totalToSpawn = spawnCount;
    }

    public void SpawnEnemies()
    {
        SpawnWave wave = waves[currentWave];
        // Check if all enemies have been spawned
        if (wave.totalSpawned < wave.totalToSpawn)
        {
            StartCoroutine(SpawnInterval());
            // Look for enemy to spawn, spawn each enemy once if spawned < toSpawn
            foreach(EnemySpawn spawn in wave.enemyList)
            {
                if(spawn.spawned < spawn.toSpawn)
                {
                    // Get random spawnPoint
                    Transform spawnPosition = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)];
                    Instantiate(spawn.enemyPrefab, spawnPosition.position, spawnPosition.rotation);
                    spawn.spawned++;
                    wave.totalSpawned++;
                }
            }
        }
    }

    IEnumerator SpawnInterval()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnInterval);
        canSpawn = true;
    }

    IEnumerator WaveInterval()
    {
        addWave = false;
        yield return new WaitForSeconds(waveInterval);
        addWave = true;
    }
}
