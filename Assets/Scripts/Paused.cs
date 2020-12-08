using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject pauseButton;

    private void Awake()
    {
        pauseMenu.SetActive(false);
    }


    public void PauseGame()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(false);
            pauseButton.SetActive(true);
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
