using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneManager : MonoBehaviour
{
    public KeyCode escapeKey;

    private void Update()
    {
        if (Input.GetKeyDown(escapeKey))
        {
            Application.Quit();
        }
        else if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Lobby");
        }
    }
}
