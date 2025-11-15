//Change scene event system
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOEvents : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        //SceneManager.LoadScene("TestStartScene");
        SceneManager.LoadScene("GameIntroTextScene");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("MainMenuStart");
    }
    public void CreditsScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
