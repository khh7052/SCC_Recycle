using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        SaveManager.OnLoad.AddListener(Init);
    }

    void Init(SaveFile saveFile)
    {
        text.text = saveFile.score.ToString("N0");
    }
}
