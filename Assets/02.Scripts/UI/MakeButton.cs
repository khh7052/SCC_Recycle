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
            UIManager.Instance.ErrorTextUpdate("현재 재료가 부족합니다!");
        }
        else
        {
            SoundManager.Instance.PlaySFX("ItemMake");
        }
    }
}
