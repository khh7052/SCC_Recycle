using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public TrashType type;
    public int num;

    public SaveData(TrashType type, int num)
    {
        this.type = type;
        this.num = num;
    }
}

public class SaveFile
{
    public SaveData[] datas;
}

public class TrashManager : Singleton<TrashManager>
{
    public Trash[] trashes;
    private SortedDictionary<TrashType, int> trashInventory = new();

    private void OnEnable()
    {
        LoadTrashFile();
    }

    private void OnDisable()
    {
        SaveTrashFile();
    }

    public void SaveTrashFile()
    {
        SaveFile saveFile = new();
        List<SaveData> datas = new();

        foreach (var item in trashInventory)
        {
            datas.Add(new(item.Key, item.Value));
        }

        saveFile.datas = datas.ToArray();
        SaveManager.Save(saveFile);
    }

    public void LoadTrashFile()
    {
        SaveFile saveFile = SaveManager.Load<SaveFile>();

        foreach (var item in saveFile.datas)
        {
            if (!trashInventory.ContainsKey(item.type)) trashInventory.Add(item.type, 0);

            trashInventory[item.type] = item.num;
            Debug.Log(item.num);
        }
    }

    public void AddTrash(TrashType type)
    {
        if(!trashInventory.ContainsKey(type)) trashInventory.Add(type, 0);

        print("Add " + type);
        trashInventory[type]++;

        // SaveTrashFile();
    }

    public Trash GetRandomTrash()
    {
        int rand = Random.Range(0, trashes.Length);
        return trashes[rand];
    }
}
