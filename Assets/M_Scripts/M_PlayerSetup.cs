using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class M_PlayerSetup : MonoBehaviour
{
    [SerializeField] M_Movement movement;
    [SerializeField] M_ShipShooting shipShooting;

    [SerializeField] GameObject Camera;

    public string nickName;

    public TextMeshPro nicknameText;

    //public Vector3 offsetNameText;

    //public int score;

    //public TextMeshPro scoreText;


    private void Update()
    {
        nicknameText.gameObject.transform.rotation = Camera.transform.rotation;
        //nicknameText.transform.position = transform.position + offsetNameText;
    }

    public void IsLocalPlayer()
    {

        movement.enabled = true;
        shipShooting.enabled = true;
        Camera.SetActive(true);
        
    }

    [PunRPC]
    public void SetNickname(string _name)
    {
        nickName = _name;

        nicknameText.text = nickName;
    }

    //[PunRPC]
    //public void SetScore(int _score)
    //{
    //    score = _score;

    //    scoreText.text = score + "";
    //}
}
