using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum TextType
{
    RECYCLE_POINT, // 재활용 포인트
    ITEM_NUM, // 아이템 개수
    SCORE,
    MAX_SCORE
}

public class SaveText : MonoBehaviour
{
    public TextType type;
    public TrashType recycleType;
    public string itemName;
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
            case TextType.RECYCLE_POINT:
                text.text = SaveManager.SaveFile.GetRecyclePoint(recycleType).ToString();
                break;
            case TextType.ITEM_NUM:
                text.text = SaveManager.SaveFile.GetItemNum(itemName).ToString();
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
