using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TrashSaveData
{
    public string trashName;
    public int trashNum;

    public TrashSaveData(string trashName, int trashNum)
    {
        this.trashName = trashName;
        this.trashNum = trashNum;
    }
}

[System.Serializable]
public class RecycleSaveData
{
    public TrashType trashType;
    public int recyclePoint;

    public RecycleSaveData(TrashType trashType, int point)
    {
        this.trashType = trashType;
        recyclePoint = point;
    }
}

public class SaveFile
{
    public int score;
    public int maxScore;
    public TrashSaveData[] trashInventoryDatas;
    public RecycleSaveData[] recycleInventorySaveDatas;
    private SortedDictionary<string, int> trashInventory = new();
    private SortedDictionary<TrashType, int> recycleInventory = new();


    public SortedDictionary<string, int> TrashInventory
    {
        get { return trashInventory; }
    }

    public void SaveScore()
    {
        score += (int)GameManager.score;
        GameManager.score = 0;

        maxScore = Mathf.Max(maxScore, (int)GameManager.maxScore);
    }

    // 인벤토리 저장
    public void SaveTrashInventory()
    {
        List<TrashSaveData> trashSaveDatas = new();

        // TrashInventory
        foreach (var item in trashInventory)
        {
            trashSaveDatas.Add(new(item.Key, item.Value));
        }

        trashInventoryDatas = trashSaveDatas.ToArray();
    }

    public void SaveRecycleInventory()
    {
        List<RecycleSaveData> recycleSaveDatas = new();

        // RecycleInventory
        foreach (var item in recycleInventory)
        {
            recycleSaveDatas.Add(new(item.Key, item.Value));
        }

        recycleInventorySaveDatas = recycleSaveDatas.ToArray();
    }

    // 인벤토리 불러오기
    public void LoadTrashInventory()
    {
        // TrashInventory
        foreach (var item in trashInventoryDatas)
        {
            if (trashInventory.ContainsKey(item.trashName)) trashInventory[item.trashName] = item.trashNum;
            else trashInventory.Add(item.trashName, item.trashNum);
        }
    }

    public void LoadRecycleInventory()
    {
        // RecycleInventory
        foreach (var item in recycleInventorySaveDatas)
        {
            if (recycleInventory.ContainsKey(item.trashType)) recycleInventory[item.trashType] = item.recyclePoint;
            else recycleInventory.Add(item.trashType, item.recyclePoint);
        }
    }


    // 모든 쓰레기 숫자
    public int GetTrashNum()
    {
        int count = 0;

        foreach (int num in trashInventory.Values)
        {
            count += num;
        }

        return count;
    }

    // 특정 쓰레기 숫자
    public int GetTrashNum(string trashName)
    {
        if (!trashInventory.ContainsKey(trashName)) return 0;

        return trashInventory[trashName];
    }

    // 랜덤한 쓰레기 종류 반환
    public List<Trash> GetRandomTrashList()
    {
        List<Trash> list = new();

        foreach (var item in trashInventory)
        {
            string trashName = item.Key;
            int trashNum = item.Value;

            Trash t = TrashManager.Instance.GetTrashInform(trashName);

            if (t == null) continue;

            for (int i = 0; i < trashNum; i++)
            {
                list.Add(t);
            }
        }

        Utility.Shuffle(list);
        return list;
    }

    // 모든 쓰레기 숫자
    public int GetRecyclePoint(TrashType type)
    {
        return recycleInventory.ContainsKey(type)? recycleInventory[type]: 0;
    }

    public void RecycleTrash(string name)
    {
        if (GetTrashNum(name) == 0) return;

        trashInventory[name]--;

        Trash trash = TrashManager.Instance.GetTrashInform(name);

        if(recycleInventory.ContainsKey(trash.Type)) recycleInventory[trash.Type]++;
        else recycleInventory.Add(trash.Type, 1);
    }

}

public class SaveManager : MonoBehaviour
{
    public static UnityEvent OnSave = new();
    public static UnityEvent<SaveFile> OnLoad = new();

    private readonly static string path = Application.dataPath + "/save.json";

    private static SaveFile saveFile = new();

    public static SaveFile SaveFile
    {
        get
        {
            return saveFile;
        }
    }

    public static void Save(object data)
    {
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        File.WriteAllText(path, json);
    }

    public static void Save()
    {
        // Score Score
        saveFile.SaveScore();

        // Save Data
        saveFile.SaveTrashInventory();
        saveFile.SaveRecycleInventory();

        // Save
        string json = JsonUtility.ToJson(saveFile);
        Debug.Log(json);
        File.WriteAllText(path, json);

        OnSave.Invoke();
    }

    public static T Load<T>()
    {
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<T>(json);
    }

    public static void Load()
    {
        string json = File.ReadAllText(path);
        saveFile = JsonUtility.FromJson<SaveFile>(json);

        // Load Data
        saveFile.LoadTrashInventory();
        saveFile.LoadRecycleInventory();

        OnLoad.Invoke(saveFile);
    }

    private void Start()
    {
        Load();
    }

    private void OnDisable()
    {
        Save();
    }

}
