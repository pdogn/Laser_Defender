using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class M_PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCpn;

    public bool player_dead = false;


    private void FixedUpdate()
    {
        //ReSpawnPlayer();

        if (player_dead)
        {
            GetComponent<PhotonView>().RPC("ReSpawnPlayer", RpcTarget.All);
            //PhotonNetwork.LocalPlayer.AddScore(-50);
            //var x = PhotonNetwork.LocalPlayer.GetScore();
            //if(x <= 0)
            //{
            //    PhotonNetwork.LocalPlayer.SetScore(0);
            //}
        }
    }

    [PunRPC]
    void ReSpawnPlayer()
    {
        StartCoroutine(Respawm());
        player_dead = false;
    }

    IEnumerator Respawm()
    {
        yield return new WaitForSeconds(0.5f);
        playerCpn.gameObject.SetActive(true);
        playerCpn.gameObject.GetComponent<M_health>().health = 20;
    }
}
