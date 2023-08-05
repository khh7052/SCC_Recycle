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

    [Header("Option")]
    public GameObject uiOption;
    public GameObject uiGameOver;
    public Image timeBar;
    public TMP_Text scoreText;
    

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

            TimeBarUpdate();
        }
    }

    public float Score
    {
        get { return score; }
        set
        {
            score = value;
            ScoreTextUpdate();
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

    void TimeBarUpdate()
    {
        if (!timeBar) return;
        timeBar.fillAmount = LeftTime / LEFT_TIME;
    }

    void ScoreTextUpdate()
    {
        if (!scoreText) return;
        scoreText.text = score.ToString("N0");
    }

    public void Init()
    {
        globalSpeed = ORIGIN_SPEED;
        Score = 0;
        LeftTime = LEFT_TIME;

        uiOption.SetActive(false);
        uiGameOver.SetActive(false);

        Time.timeScale = 1f;

        OnStart.Invoke();
    }

    public void ActiveOption(bool active)
    {
        uiOption.SetActive(active);
        Time.timeScale = active ? 0f : 1f;
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
