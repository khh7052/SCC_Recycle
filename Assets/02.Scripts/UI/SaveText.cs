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
        SaveFile.OnChange.AddListener(TextUpdate);
    }

    void Init(SaveFile saveFile)
    {
        TextUpdate();
    }

    public void TextUpdate()
    {
        switch (type)
        {
            case TextType.POINT:
                text.text = SaveManager.SaveFile.GetRecyclePoint(recycleType).ToString();
                break;
            case TextType.SCORE:
                text.text = SaveManager.SaveFile.score.ToString();
                break;
            case TextType.MAX_SCORE:
                text.text = SaveManager.SaveFile.maxScore.ToString();
                break;
            default:
                break;
        }
    }
}
