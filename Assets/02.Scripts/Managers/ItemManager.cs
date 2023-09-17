using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public Item[] items;
    public static SortedDictionary<string, Item> ItemInform = new();

    public override void Awake()
    {
        base.Awake();
        ItemInformInit();
    }

    public Item GetItemInform(string name)
    {
        if (!ItemInform.ContainsKey(name))
        {
            ItemInformInit();
            if (!ItemInform.ContainsKey(name)) return null;
        }

        return ItemInform[name];
    }

    public void ItemInformInit()
    {
        ItemInform.Clear();

        foreach (var item in items)
        {
            ItemInform.Add(item.itemName, item);
        }
    }

    public Item GetRandomTrash()
    {
        int rand = Random.Range(0, items.Length);
        return items[rand];
    }
}
