using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    const float ORIGIN_SPEED = 4f;
    const float LEFT_TIME = 60f;

    public static float globalSpeed;
    public static float score;
    public static bool isLive;
    public static float currentLeftTime;
    public GameObject uiGameOver;
    public Image timeBar;
    public UnityEvent OnStart;
    public UnityEvent OnHit;
    public UnityEvent OnGameOver;

    public float LeftTime
    {
        get { return currentLeftTime; }
        set
        {
            currentLeftTime = value;

            if (currentLeftTime <= 0)
            {
                currentLeftTime = 0f;
                globalSpeed = 0f;
                GameOver();
            }

            TimeBarUpdate();
        }
    }

    private new void Awake()
    {
        base.Awake();
        Init();
    }

    private void Update()
    {
        if (isLive) {
            score += Time.deltaTime * 2;
            LeftTime -= Time.deltaTime;
        }
    }

    void TimeBarUpdate()
    {
        timeBar.fillAmount = LeftTime / LEFT_TIME;
    }

    public void Init()
    {
        isLive = true;
        globalSpeed = ORIGIN_SPEED;
        LeftTime = LEFT_TIME;
        uiGameOver.SetActive(false);

        OnStart.Invoke();
    }

    public void HitDamage()
    {
        LeftTime -= 20f;
        OnHit.Invoke();
    }

    void GameOver()
    {
        uiGameOver.SetActive(true);
        OnGameOver.Invoke();
    }
}
