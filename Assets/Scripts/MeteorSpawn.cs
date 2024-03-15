using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : SpawnManager
{
    //[SerializeField] GameObject[] Meteor;

    //float spawnTime;
    //[SerializeField] int minTime;
    //[SerializeField] int maxTime;
    //float m_spawnTime;
    void Start()
    {
        m_spawnTime = 10f;
    }

    void Update()
    {
        m_spawnTime -= Time.deltaTime;
        if(m_spawnTime < 0f)
        {
            Spawn();
            spawnTime = Random.Range(minTime, maxTime);
            m_spawnTime = spawnTime;
        }
    }

    //protected Vector2 GetSpawnPos()
    //{
    //    float SpawnPosX = Random.Range(-5f, 5f);
    //    Vector2 SpawnPos = new Vector2(SpawnPosX, 11f);
    //    return SpawnPos;
    //}

    //void SpawnMeteor()
    //{
    //    int i = Random.Range(0, Meteor.Length-1);
    //    GameObject meteor = Instantiate(Meteor[i], GetSpawnPos(), Quaternion.identity);
    //}
}
