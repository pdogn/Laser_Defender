using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun.UtilityScripts;

public class M_ShipShooting : MonoBehaviour
{
    public bool isPlayer;

    public int timeDestroyBullet;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPos;
    [Space]
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    [Space]
    [SerializeField] protected float isShooting;

    PhotonView view;

    [Header("Enemy")]
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;

    

    private void Start()
    {
        if (isPlayer)
        {
            view = GetComponentInParent<PhotonView>();
        }
        
    }

    void Update()
    {
        if (isPlayer)
        {
            IsShooting();
        }
    }

    private void FixedUpdate()
    {
        if (isPlayer)
        {
            if (view.IsMine && PhotonNetwork.LocalPlayer.IsLocal)
            {
                Shooting();
            }
        }
        
        if (!isPlayer)
        {
            if (PhotonNetwork.IsMasterClient == true)
            {
                EnemyShoting();
            }            
        }
    }

    void IsShooting()
    {
        isShooting = Input.GetAxis("Fire1");
    }
    void Shooting()
    {
        if (isShooting == 0) return;

        //shootTimer += Time.fixedDeltaTime;
        //if (shootTimer < shootDelay) return;
        //shootTimer = 0f;

        

        if(shootTimer <= 0)
        {
            GameObject _bullet = PhotonNetwork.Instantiate(bullet.name, bulletPos.position, bulletPos.rotation);
            _bullet.gameObject.GetComponent<PhotonView>().RPC("DestroyBullet", RpcTarget.All, timeDestroyBullet);
            //_bullet.transform.SetParent(transform);
            //if(_bullet.GetComponent<M_BulletFly>().isLastBullet == true)
            //{
            //    PhotonNetwork.LocalPlayer.AddScore(100);
            //}
            shootTimer = shootDelay;
        }
        else
        {
            shootTimer -= Time.fixedDeltaTime;
        }
 
    }

    public int shootDelayy = 3;
    void EnemyShoting()
    {
        //shootDelayy = Random.Range(3, 7);

        if (shootTimer < shootDelayy)
        {          
            shootTimer += Time.fixedDeltaTime;
        }
        else
        {
            shootDelayy = Random.Range(3, 6);
            shootTimer = 0f;
            if(PhotonNetwork.LocalPlayer.IsLocal)
            {
                GameObject _bullet = PhotonNetwork.Instantiate(bullet.name, bulletPos.position, bulletPos.rotation);
                _bullet.gameObject.GetComponent<PhotonView>().RPC("DestroyBullet", RpcTarget.All, timeDestroyBullet);
            }
            
        }
        //shootTimer = 0f; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if(collision.tag == "item")
        {
            //Destroy(collision.gameObject);

            transform.GetComponent<M_ShipShooting>().shootDelay += 0.1f;
            Destroy(collision.gameObject);
        }
    }

}
