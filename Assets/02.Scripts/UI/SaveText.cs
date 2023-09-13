using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum TextType
{
    POINT,
    SCORE,
    MAX_SCORE
}

public class SaveText : MonoBehaviour
{
    public TextType type;
    public TrashType recycleType;
    TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        SaveManager.OnLoad.AddListener(Init);
    }

    void Init(SaveFile saveFile)
    {
        switch (type)
        {
            case TextType.POINT:
                text.text = saveFile.GetRecyclePoint(recycleType).ToString();
                break;
            case TextType.SCORE:
                text.text = saveFile.score.ToString();
                break;
            case TextType.MAX_SCORE:
                text.text = saveFile.maxScore.ToString();
                break;
            default:
                break;
        }

    }
}
