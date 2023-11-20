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
        trashNumText.text = $"X{num}";
    }

    public void OnActiveTrashInformation()
    {
        UIManager.Instance.ActiveTrashInformation(true);
        UIManager.Instance.TrashInformationUpdate(currentTrash);
    }
    
}
