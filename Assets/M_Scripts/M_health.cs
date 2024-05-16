using Photon.Pun;
using TMPro;
using UnityEngine;
using Photon.Pun.UtilityScripts;
using Unity.VisualScripting;

public class M_health : MonoBehaviourPunCallbacks
{
    [SerializeField] public int health;
    
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] TextMeshPro _healText;

    public int _damage = 10;

    [SerializeField] GameObject _parent;

    private void Start()
    {
        _healText.text = health.ToString();
    }

    private void FixedUpdate()
    {
        _healText.text = health.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        M_healthOfEnemy m_healEnemy = collision.gameObject.GetComponent<M_healthOfEnemy>();

        if (m_healEnemy != null)
        {
            PlayHitEffect();
        }

    }

    //public int GetHelth()
    //{
    //    return health;
    //}

    [PunRPC]
    public void TakeDamage(int damage)
    {
        health -= damage;

        _healText.text = health.ToString();
        
        if (health <= 0)
        {
            //gameObject.GetComponent<PhotonView>().RPC("Hit", RpcTarget.All);
            //PhotonNetwork.LocalPlayer.AddScore(-150);

            _parent.GetComponent<M_PlayerController>().player_dead = true;
            //PhotonNetwork.Destroy(transform.parent.gameObject);
            gameObject.SetActive(false);
 
        }
    }


    void Die()
    {
        Debug.Log("died");
        //Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            GameObject instance = PhotonNetwork.Instantiate(hitEffect.name, transform.position, Quaternion.identity);
        }
    }
}
