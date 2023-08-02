using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Cainos.CustomizablePixelCharacter;

public class DebugModeManager : Singleton<DebugModeManager>
{
    PixelCharacter mainPlayer;
    public GameObject freeMoveCam;
    public GameObject eventSystem;
    public Toggle freeMoveToggle;

    public override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += Init;
    }



    void Init(Scene scene, LoadSceneMode mode)
    {
        if (eventSystem == null) return;
        eventSystem.SetActive(true);
        EventSystem[] es = FindObjectsOfType<EventSystem>();
        eventSystem.SetActive(es.Length == 1);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnMoveScene(string sceneName)
    {
        if (freeMoveCam)
        {
            freeMoveCam.SetActive(false);
            freeMoveToggle.isOn = false;
        }

        SceneManager.LoadScene(sceneName);
    }

    public void OnPlayerFreeMove(bool active)
    {
        if (freeMoveCam == null) return;
        freeMoveCam.SetActive(active);

        mainPlayer = PixelCharacter.instance;
        

        if (mainPlayer)
        {
            if (active)
            {
                Vector3 camPos = mainPlayer.transform.position;
                camPos.z = -10;
                freeMoveCam.transform.position = camPos;
            }
            else
            {
                Vector3 playerPos = freeMoveCam.transform.position;
                playerPos.z = -0.3f;
                mainPlayer.transform.position = playerPos;
            }

            mainPlayer.gameObject.SetActive(!active);
        }
    }

}
