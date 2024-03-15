using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] bool isBoss;
    [SerializeField] int health;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;
    Scorekeeper scorekeeper;

    LevelManager levelManager;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scorekeeper = FindObjectOfType<Scorekeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        HealthDealer healthDealer = collision.GetComponent<HealthDealer>();
        //khi nhan damage
        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            audioPlayer.PlayDamageClip();
            ShakeCamera();
            if(collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("Player"))
            {
                damageDealer.Hit();
            }
        }
        //khi nhan health
        if(healthDealer != null)
        {
            TakeHealth(healthDealer.GetHealth());
            audioPlayer.PlayHealthClip();
            if (collision.gameObject.CompareTag("item") || collision.gameObject.CompareTag("Player"))
            {
                healthDealer.Hitt();
            }
        }
    }

    public int GetHelth()
    {
        return health;
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void TakeHealth(int health_bonus)
    {
        if (health < 300)
        {
            health += health_bonus;
        }
        else if(health > 300)
        {
            health = 300;
        }
    }

    void Die()
    {
        if (isBoss)
        {
            levelManager.LoadWinScene();/////
        }
        if (!isPlayer)
        {
            scorekeeper.ModifyScore(score);
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
