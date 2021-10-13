using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void MainMenu()
    {
        Debug.Log("PlayerSelection");
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("PlayerSelection", LoadSceneMode.Single);
    }

    public void LoadHelp()
    {
        SceneManager.LoadScene("Help", LoadSceneMode.Single);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Exit Game!");
        Application.Quit();
    }

    public void SelectOnePlayer()
    {
        GameControl.numberOfPlayers = 1;
        SceneManager.LoadScene("BoardScene", LoadSceneMode.Single);
    }

    public void SelectTwoPlayers()
    {
        GameControl.numberOfPlayers = 2;
        SceneManager.LoadScene("BoardScene", LoadSceneMode.Single);
    }

    public void SelectThreePlayers()
    {
        GameControl.numberOfPlayers = 3;
        SceneManager.LoadScene("BoardScene", LoadSceneMode.Single);
    }

    public void SelectFourPlayers()
    {
        GameControl.numberOfPlayers = 4;
        SceneManager.LoadScene("BoardScene", LoadSceneMode.Single);
    }
}
