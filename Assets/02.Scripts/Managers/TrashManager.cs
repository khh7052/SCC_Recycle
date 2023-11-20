using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : Singleton<TrashManager>
{
    public TrashObjectSetting[] trashObjectSettings;
    public static SortedDictionary<string, TrashObjectSetting> TrashObjectSetting = new();

    public Trash[] trashes;
    public static SortedDictionary<string, Trash> TrashInform = new();

    public TrashTypeInformation[] typeInformations;
    public static SortedDictionary<TrashType, TrashTypeInformation> TrashTypeInform = new();

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

    
    public TrashTypeInformation GetTrashTypeInform(TrashType type)
    {
        if (!TrashTypeInform.ContainsKey(type))
        {
            TrashTypeInformInit();
            if (!TrashTypeInform.ContainsKey(type)) return null;
        }

        return TrashTypeInform[type];
    }

    public void TrashInformInit()
    {
        TrashInform.Clear();

        foreach (var trash in trashes)
        {
            TrashInform.Add(trash.trashSaveName, trash);
        }
    }

    public void TrashTypeInformInit()
    {
        TrashTypeInform.Clear();

        foreach (var type in typeInformations)
        {
            TrashTypeInform.Add(type.originalType, type);
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
