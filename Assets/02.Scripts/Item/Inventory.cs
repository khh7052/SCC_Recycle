using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inventory = new();

    public void AddItem(Item item)
    {
        SoundManager.Instance.PlaySFX("AddItem", transform.position);
        inventory.Add(item);
    }

    public void ResetItem()
    {
        inventory.Clear();
    }

    public bool IsContainItem(Item item)
    {
        foreach(Item i in inventory)
        {
            if(i.itemName == item.itemName) return true;
        }


        // return inventory.Contains(item);
        return false;
    }

}
