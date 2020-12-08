using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("main");
    }

    public void GameCredits()
    {
        SceneManager.LoadScene("credits");
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    public static void EndGame()
    {
        SceneManager.LoadScene("endGame");
    }

}
