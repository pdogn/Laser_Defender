using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("Coin")]
    [SerializeField] TextMeshProUGUI coinText;

    Scorekeeper scorekeeper;

    private void Awake()
    {
        scorekeeper = FindObjectOfType<Scorekeeper>();
    }
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHelth();
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetHelth();

        scoreText.text = scorekeeper.GetScore().ToString("000000000");

        coinText.text = "Coin: " + scorekeeper.GetCoin();
    }
}
