using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0f, 1f)] float damageVolume = 1f;

    [Header("Health")]
    [SerializeField] AudioClip healthClip;
    [SerializeField][Range(0f, 1f)] float healthVolume = 1f;

    //[Space]
    //[SerializeField] GameObject _vollum;

    static AudioPlayer instance;

    private void Awake()
    {
        ManageSingleton();
    }

    private void Start()
    {
        //_vollum = GameObject.Find("SliderSound");
    }

    private void Update()
    {
        //transform.GetComponent<AudioSource>().volume = _vollum.GetComponent<Slider>().value;
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    //Damage sound
    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    //health sound
    public void PlayHealthClip()
    {
        PlayClip(healthClip, healthVolume);
    }
    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

}
