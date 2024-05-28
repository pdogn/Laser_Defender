using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    float timeDelay = 2f;
    Scorekeeper scorekeeper;
    private void Awake()
    {
        scorekeeper = FindObjectOfType<Scorekeeper>();
    }
    public void LoadGame()
    {
        scorekeeper.ResetScore();
        scorekeeper.ResetCoin();
        SceneManager.LoadScene("ChangePlayer");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOverScene", timeDelay));
    }
    public void LoadWinScene()
    {
        StartCoroutine(WaitAndLoad("WinScene", timeDelay));
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }


    public void LoadOnlMode()
    {
        //scorekeeper.ResetScore();
        SceneManager.LoadScene("M_Lobby");
    }
}
