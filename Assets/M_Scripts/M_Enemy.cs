using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Photon.Pun;
using Photon.Realtime;

public class M_Enemy : MonoBehaviour
{
    public M_PlayerSetup[] players;
    public M_PlayerSetup nearestPlayer;

    //public float enemySpeed;
    public bool roaming = true;
    public float moveSpeed;
    public float nextWPDistance;

    public Seeker seeker;
    public bool updateContinuesPath;
    bool reachDestination = false; //kiem tra enemy đã đi hết path chưa
    Path path;
    Coroutine moveCoroutine;

    Rigidbody2D rb;

    M_ShipShooting enemyShoting;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        players = FindObjectsOfType<M_PlayerSetup>();
        InvokeRepeating("FindPlayer", 0f, 1.5f);

        enemyShoting = GetComponent<M_ShipShooting>();

        //FindNearestPlayer();
        InvokeRepeating("CaculatePath",0f, 0.5f);
        reachDestination = true;
    }

    private void Update()
    {
        if(nearestPlayer != null)
        {
            EnemyRotate();

            float _distance = Vector2.Distance(transform.position, nearestPlayer.gameObject.transform.position);
            if(_distance <= 10)
            {
                enemyShoting.enabled = true;
            }
            else
            {
                enemyShoting.enabled = false;
            }
        }
        
        //FindNearestPlayer();
        //EnemyMove();
    }

    //void EnemyMove()
    //{
    //    //float distanceOne = Vector2.Distance(transform.position, players[0].transform.position);
    //    //float distanceTwo = Vector2.Distance(transform.position, players[1].transform.position);

    //    //if(distanceOne < distanceTwo)
    //    //{
    //    //    nearestPlayer = players[0];
    //    //}
    //    //else
    //    //{
    //    //    nearestPlayer = players[1];
    //    //}

    //    if (nearestPlayer != null)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, nearestPlayer.transform.position, enemySpeed * Time.deltaTime);
    //    }
    //}

    //void FindNearestPlayer()
    //{
    //    float minDistance = Mathf.Infinity;
    //    foreach (M_PlayerSetup player in players)
    //    {
    //        float distance = Vector2.Distance(transform.position, player.transform.position);
    //        if (distance < minDistance)
    //        {
    //            minDistance = distance;
    //            nearestPlayer = player;
    //        }
    //    }
    //}

    void FindPlayer()
    {
        players = new M_PlayerSetup[0];
        players = FindObjectsOfType<M_PlayerSetup>();
    }

    void CaculatePath()
    {
        FindNearestPlayer();
        Vector2 target = FindTarget();

        if (seeker.IsDone() && (reachDestination || updateContinuesPath))
        {
            seeker.StartPath(transform.position, target, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (p.error) return;
        path = p;
        //Move to target
        MoveToTarget();
    }


    void MoveToTarget()
    {
        if(moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }

    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;
        reachDestination = false;

        while(currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)force;

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWPDistance)
                currentWP++;

            yield return null;
        }
        reachDestination = true;
    }

    public float minDistance;
    public float maxDistance;
    Vector2 FindTarget()
    {
        Vector3 playerPos = new Vector3();
        if (nearestPlayer != null)
        {
            playerPos = nearestPlayer.transform.position;
        }
        //Vector3 playerPos = nearestPlayer.transform.position;
        if(roaming == true)
        {
            return (Vector2)playerPos + (Random.Range(minDistance, maxDistance) * new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized);
        }
        else
        {
            return playerPos;
        }
    }

    void FindNearestPlayer()
    {
        float minDistance = Mathf.Infinity;
        foreach (M_PlayerSetup player in players)
        {
            if(player == null) continue;
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPlayer = player;
            }
        }
    }

    void EnemyRotate()
    {
        Vector2 plPos = new Vector2(nearestPlayer.transform.position.x, nearestPlayer.transform.position.y);
        Vector2 lookdir = plPos - rb.position;
        float Angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg + 90;
        rb.rotation = Angle;
    }

    //[PunRPC]
    //public void DestroyEnemy()
    //{
    //    Destroy(gameObject);
    //}

}
