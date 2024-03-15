using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    [SerializeField] int spawnTime;
    float m_spawnTime;

    void Update()
    {
        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime < 0f)
        {
            SpawnBullet();
            spawnTime = Random.Range(3, spawnTime);
            m_spawnTime = spawnTime;
        }
    }

    void SpawnBullet()
    {
        float SpawnPosX = Random.Range(transform.position.x, transform.position.x + 2.5f);
        Vector2 SpawnPos = new Vector2(SpawnPosX, transform.position.y);
        GameObject bulletBoss = Instantiate(bullet, SpawnPos, Quaternion.identity);

        Destroy(bulletBoss, 5f);
    }
}
