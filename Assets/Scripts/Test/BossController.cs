using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] Transform bossPath;
    [SerializeField] float bossSpeed;
    List<Transform> bossPoint = new List<Transform>();

    int i;
    void Start()
    {
        GetBossPoints();
        i = 0;
    }

    void Update()
    {
        BossMove();
    }

    void BossMove()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                bossPoint[i].position, 
                                                bossSpeed * Time.deltaTime);
        if (transform.position == bossPoint[i].position)
        {
            //lay vi tri ngau nhien trong list poit
            i = Random.Range(0, bossPoint.Count - 1);
        }
    }
    public void GetBossPoints()
    {
        List<Transform> Bosspoints = new List<Transform>();
        foreach (Transform child in bossPath)
        {
            Bosspoints.Add(child);
        }
        bossPoint = Bosspoints;
    }

}
