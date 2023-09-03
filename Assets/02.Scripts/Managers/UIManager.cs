using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UIManager : Singleton<UIManager>
{
    [Header("Common")]
    public GameObject uiOption;
    public GameObject uiGameOver;
    

    [Header("Collect Game")]
    public Image timeBar;
    public TMP_Text scoreText;
    public TMP_Text maxScoreText;

    [Header("SperateEmission")]
    public GameObject uiSperateGameEnd;
    public TMP_Text currentTrashNumText; // 현재 남은 쓰레기 개수
    

    public override void Awake()
    {
        base.Awake();
        SaveManager.OnLoad.AddListener(Init);
    }

    private void Start()
    {
        ActiveOption(false);
        ActiveGameOver(false);
        ActiveSperateGameEnd(false);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        ActiveOption(false);
    }
    
    public void Init(SaveFile saveFile)
    {
        MaxScoreTextUpdate(saveFile.maxScore);
    }

    public void ActiveOption(bool active)
    {
        if (!uiOption) return;

        uiOption.SetActive(active);
        Time.timeScale = active ? 0f : 1f;
    }
    public void ActiveGameOver(bool active)
    {
        if (!uiGameOver) return;

        uiGameOver.SetActive(active);
    }

    public void TimeBarUpdate(float amount)
    {
        if (!timeBar) return;
        timeBar.fillAmount = amount;
    }

    public void ScoreTextUpdate(float amount)
    {
        if (!scoreText) return;
        scoreText.text = amount.ToString("N0");

    }
    public void MaxScoreTextUpdate(float amount)
    {
        if (!maxScoreText) return;
        maxScoreText.text = amount.ToString("N0");
    }

    public void CurrentTrashNumTextUpdate()
    {
        if (!currentTrashNumText) return;

        int trashNum = SaveManager.SaveFile.GetTrashNum();
        currentTrashNumText.text = trashNum.ToString();
    }

    public void ActiveSperateGameEnd(bool active)
    {
        if (!uiSperateGameEnd) return;

        uiSperateGameEnd.SetActive(active);
    }
}
