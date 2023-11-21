using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrashButton : MonoBehaviour
{
    public Image iconImage;
    public TMP_Text nameText;
    public TMP_Text numText;
    public Trash trash;

    private void Awake()
    {
        SaveManager.OnLoad.AddListener(Init);
    }

    void Init(SaveFile saveFile)
    {
        if (!trash)
        {
            nameText.text = "";
            numText.text = "";
            return;
        }

        iconImage.sprite = trash.sprite;
        nameText.text = trash.trashRealName;
        numText.text = saveFile.GetTrashNum(trash.trashSaveName).ToString();
    }
}
