using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class M_damageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;

    public int GetDamage()
    {
        return damage;
    }

    [PunRPC]
    public void Hit()
    {
        Destroy(gameObject);
    }
}
