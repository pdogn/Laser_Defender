using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject audioPl;

    [SerializeField] GameObject SettingSC;

    [SerializeField] GameObject soundSlider;

    [SerializeField] GameObject pauseBtn;


    private void Start()
    {
        audioPl = GameObject.Find("Audio Player");
        //soundSlider = GameObject.Find("SliderSound");
    }

    private void Update()
    {
        if(soundSlider != null)
        {
            audioPl.GetComponent<AudioSource>().volume = soundSlider.GetComponent<Slider>().value;
        }
    }


    public void LoadSettingSC()
    {
        Time.timeScale = 0;

        if(pauseBtn != null)
        {
            pauseBtn.SetActive(false);
        }

        if(SettingSC != null)
        {
            SettingSC.SetActive(true);
        }
        

        audioPl = GameObject.Find("Audio Player");

        soundSlider = GameObject.Find("SliderSound");
        if(soundSlider != null )
        {
            soundSlider.GetComponent<Slider>().value = audioPl.GetComponent<AudioSource>().volume;
        }     
    }

    public void Exits()
    {
        Time.timeScale = 1;
        SettingSC.SetActive(false);
        if (pauseBtn != null)
        {
            pauseBtn.SetActive(true);
        }
    }

    public void BackScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void PauseGame()
    {
        SettingSC.SetActive(true);

        soundSlider = GameObject.Find("SliderSound");
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void RePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("ShopScene");
    }
}
