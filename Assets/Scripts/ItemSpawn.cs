using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : SpawnManager
{
    void Start()
    {
        m_spawnTime = 10f;
    }

    void Update()
    {
        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime < 0f)
        {
            Spawn();
            spawnTime = Random.Range(minTime, maxTime);
            m_spawnTime = spawnTime;
        }
    }
}
