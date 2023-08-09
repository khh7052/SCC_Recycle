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
    public TrashType type;

    private void Awake()
    {
        SaveManager.OnLoad.AddListener(Init);
    }

    void Init(SaveFile saveFile)
    {
        Trash trash = TrashManager.Instance.GetTrash(type);
        iconImage.sprite = trash.sprite;
        nameText.text = trash.trashName;

        numText.text = saveFile.GetTrashNum(type).ToString();
    }
}
