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
    public static float currentLeftTime;

    [Header("Event")]
    public UnityEvent OnStart;
    public UnityEvent OnHit;
    public UnityEvent OnGameOver;

    public static bool IsLive
    {
        get
        {
            return currentLeftTime > 0f;
        }
    }

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

            UIManager.Instance.TimeBarUpdate(currentLeftTime / LEFT_TIME);
        }
    }

    public float Score
    {
        get { return score; }
        set
        {
            score = value;
            UIManager.Instance.ScoreTextUpdate(score);
        }
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (!IsLive) return;

        Score += Time.deltaTime * 2;
        LeftTime -= Time.deltaTime;
    }

    public void Init()
    {
        globalSpeed = ORIGIN_SPEED;
        Score = 0;
        LeftTime = LEFT_TIME;

        Time.timeScale = 1f;

        OnStart.Invoke();
    }

    public void HitDamage()
    {
        LeftTime -= 20f;
        OnHit.Invoke();
    }

    void GameOver()
    {
        UIManager.Instance.ActiveGameOver(true);
        OnGameOver.Invoke();
    }
}
