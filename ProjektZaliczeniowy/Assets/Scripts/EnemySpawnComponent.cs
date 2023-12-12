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

    public GameState gameState;
    public WaveInfo waveInfo;
    public List<SpawnWave> waves;
    public List<Transform> spawnPoints;

    private int currentWave;
    private bool canSpawn = true;
    // Time inbetween spawns
    private float spawnInterval = 0.5f;

    private void Start()
    {
        TotalToSpawn();
        // Init wave info, currentWave + 1 cause it starts from 0
        waveInfo.SetTotalWaves(waves.Count);
        waveInfo.SetCurrentWave(currentWave + 1);
    }

    void Update()
    {
        if(canSpawn)
        {
            SpawnEnemies();
        }
    }

    public void AddWave()
    {
        currentWave++;
        // Check if it is last wave and stop spawning
        if (currentWave >= waves.Count)
        {
            canSpawn = false;
            gameState.Victory();
            return;
        }
        else
        {
            waveInfo.SetCurrentWave(currentWave + 1);
            TotalToSpawn();
        }
    }

    // Calculate how many enemies to spawn this wave
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
        List<EnemySpawn> possibleSpawns = new List<EnemySpawn>();
        if (wave.totalSpawned < wave.totalToSpawn)
        {
            StartCoroutine(SpawnInterval());
            // Look for enemy to spawn if spawned < toSpawn
            foreach(EnemySpawn spawn in wave.enemyList)
            {
                if(spawn.spawned < spawn.toSpawn)
                {
                    possibleSpawns.Add(spawn);
                }
            }
            // Get random spawnPoint
            Transform spawnPosition = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)];
            // Get random possible enemy to spawn
            EnemySpawn enemy = possibleSpawns[UnityEngine.Random.Range(0, possibleSpawns.Count)];
            Instantiate(enemy.enemyPrefab, spawnPosition.position, Quaternion.identity);
            enemy.spawned++;
            wave.totalSpawned++;
        }
        else
        {
            AddWave();
        }
    }

    IEnumerator SpawnInterval()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnInterval);
        canSpawn = true;
    }
}
