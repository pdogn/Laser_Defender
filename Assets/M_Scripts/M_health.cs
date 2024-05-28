using Photon.Pun;
using TMPro;
using UnityEngine;
using Photon.Pun.UtilityScripts;
using Unity.VisualScripting;
using UnityEngine.UI;

public class M_health : MonoBehaviourPunCallbacks
{
    [SerializeField] public float health;
    
    [SerializeField] ParticleSystem hitEffect;

    //[SerializeField] TextMeshPro _healText;

    [SerializeField] Slider _healthSlider;

    public int _damage = 10;

    [SerializeField] GameObject _parent;

    private void Start()
    {
        //_healText.text = health.ToString();
        _healthSlider.value = health / 100;
    }

    private void FixedUpdate()
    {
        //_healText.text = health.ToString();
        _healthSlider.value = health / 100;
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

        //_healText.text = health.ToString();
        
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
