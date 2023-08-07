using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UIManager : Singleton<UIManager>
{
    public GameObject uiOption;
    public GameObject uiGameOver;
    public Image timeBar;
    public TMP_Text scoreText;

    private void Start()
    {
        ActiveOption(false);
        ActiveGameOver(false);
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
}
