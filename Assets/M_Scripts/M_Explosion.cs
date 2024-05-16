using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Explosion : MonoBehaviour
{
    public float timeToDestroy = 1.5f;

    private void Start()
    {
        timeToDestroy = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToDestroy > 0)
        {
            timeToDestroy -= Time.deltaTime;
        }
        else
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
