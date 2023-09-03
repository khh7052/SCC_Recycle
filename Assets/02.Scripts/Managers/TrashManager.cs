using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : Singleton<TrashManager>
{
    public TrashObjectSetting[] trashObjectSettings;
    public static SortedDictionary<string, TrashObjectSetting> TrashObjectSetting = new();

    public Trash[] trashes;
    public static SortedDictionary<string, Trash> TrashInform = new();
    public static SortedDictionary<string, int> TrashInventory = new();
    public static SortedDictionary<string, int> TrashInventory_Refine = new();

    public override void Awake()
    {
        base.Awake();
        TrashInformInit();
        TrashSettingInit();
        TrashInventory.Clear();
    }

    public Trash GetTrashInform(string name)
    {
        if (!TrashInform.ContainsKey(name))
        {
            TrashInformInit();
            if (!TrashInform.ContainsKey(name)) return null;
        }

        return TrashInform[name];
    }

    public void TrashInformInit()
    {
        TrashInform.Clear();

        foreach (var trash in trashes)
        {
            TrashInform.Add(trash.trashName, trash);
        }
    }

    public void TrashSettingInit()
    {
        foreach (var setting in trashObjectSettings)
        {
            TrashObjectSetting.Add(setting.sceneName, setting);
        }
    }

    public void AddTrash(string name)
    {
        if(!TrashInventory.ContainsKey(name)) TrashInventory.Add(name, 0);

        print("Add " + name);
        TrashInventory[name]++;
    }

    public Trash GetRandomTrash()
    {
        int rand = Random.Range(0, trashes.Length);
        return trashes[rand];
    }
}
