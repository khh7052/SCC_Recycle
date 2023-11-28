using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorPause : MonoBehaviour
{
    public bool isTimePause = true;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(isTimePause)
                Time.timeScale = isPaused ? 1 : 0;
            else
                Debug.Break();

            isPaused = !isPaused;
        }
    }
}
