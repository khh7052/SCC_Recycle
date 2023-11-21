using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeparateResultTrashButton : MonoBehaviour
{
    public Image trashImage;
    public TMP_Text trashNumText;
    private Trash currentTrash;

    public void Init(Trash trash, int num)
    {
        currentTrash = trash;
        trashImage.sprite = trash.sprite;

        if (num > 0)
            trashNumText.text = $"X{num}";
        else
            trashNumText.text = "";
    }

    public void OnActiveTrashInformation()
    {
        UIManager.Instance.ActiveTrashInformation(true);
        UIManager.Instance.TrashInformationUpdate(currentTrash);
    }
    
}
