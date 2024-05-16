using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun.UtilityScripts;

public class M_BulletFly : MonoBehaviour
{
    public bool isPlayerBullet;
    [SerializeField] protected int moveSpeed = 1;
    [SerializeField] protected Vector2 direction = Vector2.up;

    public int _damage = 10;

    [SerializeField] ParticleSystem hitEffect;

    public bool isLastBullet = false;

    void Update()
    {
        if (isPlayerBullet)
        {
            transform.Translate(moveSpeed * Time.deltaTime * direction);
        }
        else
        {
            transform.Translate(-moveSpeed * Time.deltaTime * direction);
        }
        
    }

    [PunRPC]
    public void DestroyBullet(int timeToDestroy)
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPlayerBullet)
        {
            M_healthOfEnemy m_healEnemy = collision.gameObject.GetComponent<M_healthOfEnemy>();

            if(m_healEnemy != null)
            {
                if(m_healEnemy.health <= _damage)
                {
                    isLastBullet = true;
                    if (PhotonNetwork.LocalPlayer.IsLocal)
                    {
                        PhotonNetwork.LocalPlayer.AddScore(100);
                    }
                        
                }

                collision.gameObject.GetComponent<PhotonView>().RPC("EnemyTakeDamage", RpcTarget.All, _damage);

                PlayHitEffect();

                PhotonNetwork.Destroy(gameObject);
            }
        }
        else
        {
            M_health m_health = collision.gameObject.GetComponent<M_health>();

            if (m_health != null)
            {
                collision.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, _damage);

                PlayHitEffect();

                PhotonNetwork.Destroy(gameObject);
            }
        }
       
    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            GameObject instance = PhotonNetwork.Instantiate(hitEffect.name, transform.position, Quaternion.identity);
        }
    }
}
