using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    int score;
    public int TotalCoin;
    private const string totalCoinKey = "TotalCoinKey";
    public string GetTotalCoinKey
    {
        get { return totalCoinKey; }
    }

    public int coin;

    public static Scorekeeper instance;

    private void Awake()
    {
        ManageSingleton();
    }

    private void Start()
    {
        TotalCoin = PlayerPrefs.GetInt(totalCoinKey);
    }

    void ManageSingleton()
    {
        if (instance != null)
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
    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void ResetCoin()
    {
        coin = 0;
    }

    public int GetCoin()//coin luc choi
    {
        return coin;
    }

    public void SaveTotalCoin()
    {
        PlayerPrefs.SetInt(totalCoinKey, TotalCoin);
        PlayerPrefs.Save();
    }

    public int GetTotalCoin()//Tong coin
    {
        TotalCoin = PlayerPrefs.GetInt(totalCoinKey);
        return TotalCoin;
    }
}
