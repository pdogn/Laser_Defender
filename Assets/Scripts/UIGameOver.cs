using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    Scorekeeper scorekeeper;

    private void Awake()
    {
        scorekeeper = FindObjectOfType<Scorekeeper>();
    }

    void Start()
    {
        scoreText.text = "YOU SCORED:\n" + scorekeeper.GetScore();
    }
}
