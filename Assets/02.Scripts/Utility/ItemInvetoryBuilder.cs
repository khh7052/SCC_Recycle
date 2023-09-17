using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInvetoryBuilder : MonoBehaviour
{
    public Transform parent;
    public ItemButton itemButton;
    public ItemManager itemManager;

    private void Start()
    {
        MakeInventory();
    }

    [ContextMenu("Make Inventory")]
    void MakeInventory()
    {
        if (parent == null) return;
        if (itemButton == null) return;
        if (itemManager == null) return;

        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(parent.GetChild(i).gameObject);
        }

        foreach (var item in itemManager.items)
        {
            ItemButton button = Instantiate(itemButton, parent);
            button.CreateCostUI(item);
        }
    }

}
