using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // TODO Refactor
    public void GoToLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void GoToOptions()
    {
        Debug.Log("Options scene loaded");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

