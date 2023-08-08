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

    private void Start()
    {
        Trash trash = TrashManager.Instance.GetTrash(type);
        iconImage.sprite = trash.sprite;
        nameText.text = trash.trashName;
        // numText.text = TrashManager.Instance.trashInventory[type].ToString();
        numText.text = TrashManager.Instance.GetTrashNum(type).ToString();
    }
}
