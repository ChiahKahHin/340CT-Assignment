using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuUI;

    public void Resume()
    {
        Debug.Log("Resume Game...");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Debug.Log("Game Paused...");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void loadMenu()
    {
        Debug.Log("Back to Main Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
