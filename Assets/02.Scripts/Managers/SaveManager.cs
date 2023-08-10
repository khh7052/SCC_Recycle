using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TrashSaveData
{
    public TrashType type;
    public int num;

    public TrashSaveData(TrashType type, int num)
    {
        this.type = type;
        this.num = num;
    }
}

public class SaveFile
{
    public float score;
    public float maxScore;
    public TrashSaveData[] datas;
    private SortedDictionary<TrashType, int> trashInventory = new();

    public void SaveScore()
    {
        score += GameManager.score;
        GameManager.score = 0;

        maxScore = Mathf.Max(maxScore, GameManager.maxScore);
    }

    // 인벤토리 저장
    public void SaveTrashInventory()
    {
        // 문제점 : 저장 개수가 다름
        // 
        List<TrashSaveData> trashSaveDatas = new();
        foreach (var item in TrashManager.TrashInventory)
        {
            TrashType type = item.Key;
            int num = item.Value;

            trashInventory[type] += num;
        }

        foreach (var item in trashInventory)
        {
            trashSaveDatas.Add(new(item.Key, item.Value));
        }

        datas = trashSaveDatas.ToArray();
    }

    // 인벤토리 불러오기
    public void LoadTrashInventory()
    {
        Debug.Log("LoadInventory");
        trashInventory.Clear();

        for (int i = 0; i < (int)TrashType.LENGTH; i++)
        {
            TrashType type = (TrashType)i;
            trashInventory.Add(type, 0);
        }

        foreach (var item in datas)
        {
            Debug.Log(item.type);
            trashInventory[item.type] = item.num;
        }
    }

    public int GetTrashNum(TrashType type)
    {
        if (!trashInventory.ContainsKey(type)) return 0;

        return trashInventory[type];
    }

}

public class SaveManager : MonoBehaviour
{
    public static UnityEvent OnSave = new();
    public static UnityEvent<SaveFile> OnLoad = new();

    private readonly static string path = Application.dataPath + "/save.json";

    private static SaveFile saveFile = new();

    public static void Save(object data)
    {
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        File.WriteAllText(path, json);
    }

    public static void Save()
    {
        // Score
        saveFile.SaveScore();

        // TrashSaveData
        saveFile.SaveTrashInventory();

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
        saveFile.LoadTrashInventory();
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
