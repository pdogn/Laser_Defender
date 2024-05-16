using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class M_healthOfEnemy : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] int maxHealth;
    [SerializeField] int score = 50;
    public int _damage1 = 10;

    [SerializeField] TextMeshPro _healText;

    [SerializeField] Slider healthSlider;

    M_EnemySpawner enemySpawn;

    //[SerializeField] M_FloatingHealthBar healthBar;

    private void Start()
    {
        enemySpawn = FindObjectOfType<M_EnemySpawner>();

        //healthBar = GetComponentInChildren<M_FloatingHealthBar>();
        health = maxHealth;
        _healText.text = health.ToString();
        healthSlider.value = health / maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        M_health health = collision.gameObject.GetComponent<M_health>();
        if (health != null)
        {
            collision.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, _damage1);

            enemySpawn.currentEnemies--;
            PhotonNetwork.Destroy(gameObject);
        }           
    }

    //public int GetHelth()
    //{
    //    return health;
    //}

    [PunRPC]
    public void EnemyTakeDamage(int damage)
    {
        //maxHealth = 20;
        health -= damage;

        _healText.text = health+"";

        healthSlider.value = ((float)health / maxHealth);

        if (health <= 0)
        {
            //gameObject.GetComponent<PhotonView>().RPC("Hit", RpcTarget.All);

            //PhotonNetwork.Destroy(transform.parent.gameObject);enemySpawn.currentEnemies--;
            enemySpawn.currentEnemies--;

            PhotonNetwork.Destroy(gameObject);

        }
    }

   
}
