using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : Singleton<TrashManager>
{
    public TrashObjectSetting[] trashObjectSettings;
    public static SortedDictionary<string, TrashObjectSetting> TrashObjectSetting = new();

    public Trash[] trashes;
    public static SortedDictionary<string, Trash> TrashInform = new();

    public override void Awake()
    {
        base.Awake();
        TrashInformInit();
        TrashSettingInit();
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
        TrashObjectSetting.Clear();

        foreach (var setting in trashObjectSettings)
        {
            TrashObjectSetting.Add(setting.sceneName, setting);
        }
    }

    public void AddTrash(string name)
    {
        var inventory = SaveManager.SaveFile.TrashInventory;

        if (!inventory.ContainsKey(name)) inventory.Add(name, 0);

        inventory[name]++;
    }

    public Trash GetRandomTrash()
    {
        int rand = Random.Range(0, trashes.Length);
        return trashes[rand];
    }
}
