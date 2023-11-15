using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeButton : MonoBehaviour
{
    public Item item;

    public void OnMake()
    {
        if (!SaveManager.SaveFile.MakeItem(item.itemName))
        {
            UIManager.Instance.ErrorTextUpdate("���� ��ᰡ �����մϴ�!");
        }
        else
        {
            SoundManager.Instance.PlaySFX("ItemMake");
        }
    }
}
