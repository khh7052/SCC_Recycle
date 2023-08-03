using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Cainos.CustomizablePixelCharacter;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class GameManager : Singleton<GameManager>
{
    public static bool ApplicationIsQuitting = false;
    public static UnityEvent OnPlayerDie = new();
    public bool isPlayerDying = false;
    public Transform savePoint;

    private void Start()
    {
        ApplicationIsQuitting = false;
    }

    public void PlayerDie()
    {
        isPlayerDying = true;
        ResetPlayer();
        OnPlayerDie.Invoke();
        isPlayerDying = false;
    }


    public void ResetPlayer()
    {
        if (savePoint) 
            PixelCharacter.instance.transform.position = savePoint.position; // 세이브 위치로 이동

        //Player.Instance.Init();
    }

    private void OnApplicationQuit()
    {
        ApplicationIsQuitting = true;
    }
}
