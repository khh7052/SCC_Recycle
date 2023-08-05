using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void GameExit()
    {
        Application.Quit();
    }

    public static void Continue()
    {
        Time.timeScale = 1.0f;
    }
}
