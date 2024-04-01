using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves;
    WaveConfigSO currentWave;

    [SerializeField] bool isLooping;
   
    [SerializeField] GameObject bossPref;
    [SerializeField] bool isSpawn = true;
    [SerializeField] int n_score = 500;
    Scorekeeper scorekeeper;

    private void Awake()
    {
        scorekeeper = FindObjectOfType<Scorekeeper>();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemyWave());
    }

    private void Update()
    {
        if (scorekeeper.GetScore() >= n_score && isSpawn)
        {
            isLooping = false;
            //spawn boss
            SpawnBoss();
            isSpawn = false;
        }
    }

    //Get current Wave
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWave()  //Spawn
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                            currentWave.GetStartingWaypoint().position,
                            Quaternion.Euler(0,0,180),
                            transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (isLooping);
    }

    void SpawnBoss()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 12);
        GameObject bossClone = Instantiate(bossPref, spawnPos, Quaternion.identity, transform);
    }
}
