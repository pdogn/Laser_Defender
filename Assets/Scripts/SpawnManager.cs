using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Meteor;

    protected float spawnTime;
    public int minTime;
    public int maxTime;
    protected float m_spawnTime;//spawn after time

    protected Vector2 GetSpawnPos()
    {
        float SpawnPosX = Random.Range(-5f, 5f);
        Vector2 SpawnPos = new Vector2(SpawnPosX, 11f);
        return SpawnPos;
    }

    protected void Spawn()
    {
        int i = Random.Range(0, Meteor.Length - 1);
        GameObject meteor = Instantiate(Meteor[i], GetSpawnPos(), Quaternion.identity);
    }
}
