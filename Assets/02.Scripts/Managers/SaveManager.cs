using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TrashSaveData
{
    public string trashName;
    public int num;

    public TrashSaveData(string trashName, int num)
    {
        this.trashName = trashName;
        this.num = num;
    }
}

public class SaveFile
{
    public int score;
    public int maxScore;
    public int recyclePoint;
    public TrashSaveData[] datas;
    private SortedDictionary<string, int> trashInventory = new();

    public void SaveScore()
    {
        score += (int)GameManager.score;
        GameManager.score = 0;

        maxScore = Mathf.Max(maxScore, (int)GameManager.maxScore);
    }

    // 인벤토리 저장
    public void SaveTrashInventory()
    {
        // 문제점 : 저장 개수가 다름
        // 
        List<TrashSaveData> trashSaveDatas = new();
        foreach (var item in TrashManager.TrashInventory)
        {
            string trashName = item.Key;
            int num = item.Value;

            trashInventory[trashName] += num;
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

        foreach (var item in TrashManager.Instance.trashes)
        {
            trashInventory.Add(item.trashName, 0);
        }

        foreach (var item in datas)
        {
            Debug.Log(item.trashName);
            trashInventory[item.trashName] = item.num;
        }
    }

    public int GetTrashNum(string trashName)
    {
        if (!trashInventory.ContainsKey(trashName)) return 0;

        return trashInventory[trashName];
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
