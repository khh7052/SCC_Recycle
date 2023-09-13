using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCostUI : MonoBehaviour
{
    public Image typeImage;
    public TMP_Text costText;

    public void UI_Update(CostData costData)
    {
        typeImage.sprite = TrashManager.Instance.GetTrashTypeInform(costData.trashType).typeSprite;
        costText.text = costData.cost.ToString();
    }


}
