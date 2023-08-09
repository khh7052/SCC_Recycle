using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ScoreType
{
    NOW,
    MAX
}

public class ScoreText : MonoBehaviour
{
    public ScoreType type;
    TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        SaveManager.OnLoad.AddListener(Init);
    }

    void Init(SaveFile saveFile)
    {
        text.text = type == ScoreType.NOW ? saveFile.score.ToString("N0") : saveFile.maxScore.ToString("N0");
    }
}
