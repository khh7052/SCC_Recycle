using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public float ORIGIN_SPEED = 1.5f;
    public float LEFT_TIME = 60f;

    public static float globalSpeed;
    public static float score;
    public static float maxScore;
    public static float currentLeftTime;

    [Header("Event")]
    public UnityEvent OnStart;
    public UnityEvent OnHit;
    public UnityEvent OnGameOver;
    public UnityEvent<float> OnLeftTimeChange;
    public UnityEvent<float> OnScoreChange;
    public UnityEvent<float> OnMaxScoreChange;

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

            OnLeftTimeChange.Invoke(currentLeftTime / LEFT_TIME);
        }
    }

    public float Score
    {
        get { return score; }
        set
        {
            score = value;
            OnScoreChange.Invoke(score);

            if(score > maxScore)
            {
                maxScore = score;
                OnMaxScoreChange.Invoke(score);
            }
        }
    }

    public override void Awake()
    {
        base.Awake();
        SaveManager.OnLoad.AddListener(Init);
    }

    private void Update()
    {
        if (!IsLive) return;

        Score += Time.deltaTime * 2;
        LeftTime -= Time.deltaTime;
    }

    public void Init(SaveFile saveFile)
    {
        globalSpeed = ORIGIN_SPEED;
        Score = 0;
        LeftTime = LEFT_TIME;

        Time.timeScale = 1f;

        maxScore = saveFile.maxScore;
        SoundManager.Instance.StopSFX();
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
        SoundManager.Instance.PlaySFX("GameOver");
        SoundManager.Instance.StopBGM();
        OnGameOver.Invoke();
    }
}
