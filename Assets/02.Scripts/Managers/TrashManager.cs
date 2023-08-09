using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : Singleton<TrashManager>
{
    public Trash[] trashes;
    public static SortedDictionary<TrashType, Trash> TrashInform = new();
    public static SortedDictionary<TrashType, int> TrashInventory = new();


    public override void Awake()
    {
        base.Awake();
        TrashInformInit();
        TrashInventory.Clear();
    }


    public Trash GetTrash(TrashType type)
    {
        if (!TrashInform.ContainsKey(type))
        {
            TrashInformInit();
            if (!TrashInform.ContainsKey(type)) return null;
        }

        return TrashInform[type];
    }
    public void TrashInformInit()
    {
        TrashInform.Clear();

        foreach (var trash in trashes)
        {
            TrashInform.Add(trash.type, trash);
        }
    }

    public void AddTrash(TrashType type)
    {
        if(!TrashInventory.ContainsKey(type)) TrashInventory.Add(type, 0);

        print("Add " + type);
        TrashInventory[type]++;
    }

    public Trash GetRandomTrash()
    {
        int rand = Random.Range(0, trashes.Length);
        return trashes[rand];
    }
}
