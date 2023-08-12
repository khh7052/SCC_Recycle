using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButton : MonoBehaviour
{
    public Image iconImage;
    public TMP_Text nameText;
    public TMP_Text pointText;
    public Item item;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        if (!item) return;

        iconImage.sprite = item.sprite;
        nameText.text = item.itemName;
        pointText.text = item.point.ToString();
    }
}
