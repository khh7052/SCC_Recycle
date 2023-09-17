using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButton : MonoBehaviour
{
    public Image iconImage;
    public TMP_Text nameText;
    public TMP_Text numText;
    public Transform costParent;

    public Item item;
    public ItemCostUI costUI;

    private void Awake()
    {
        Init();
        SaveFile.OnChange.AddListener(NumTextUpdate);
    }
    private void Start()
    {
        CreateCostUI();
    }

    void Init()
    {
        ItemUIUpdate();
    }

    void NumTextUpdate()
    {
        if (numText) numText.text = SaveManager.SaveFile.GetItemNum(item.itemName).ToString();
    }

    void ItemUIUpdate()
    {
        if (!item)
        {
            iconImage.sprite = null;
            nameText.text = "";
            return;
        }

        if (iconImage) iconImage.sprite = item.sprite;
        if (nameText) nameText.text = item.itemName;
        NumTextUpdate();
    }

    public void OnButtonClick()
    {
        UIManager.Instance.ActiveItemInventory(false);
        UIManager.Instance.ActiveItemCreate(true);
        UIManager.Instance.ItemButtonUpdate(item);
    }
    

    [ContextMenu("Create Cost UI")]
    public void CreateCostUI()
    {
        if (costUI == null) return;
        if (costParent == null) return;
        if (item == null) return;

        for (int i = costParent.childCount-1; i >= 0; i--)
        {
            DestroyImmediate(costParent.GetChild(i).gameObject);
        }

        foreach (var data in item.costDatas)
        {
            ItemCostUI ui = Instantiate(costUI, costParent);
            ui.UI_Update(data);
        }

        ItemUIUpdate();
    }

    public void CreateCostUI(Item item)
    {
        this.item = item;
        CreateCostUI();
    }
}
