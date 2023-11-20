using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class EmissionManager : Singleton<EmissionManager>
{
    public UnityEvent OnEnd;

    public TrashSpawner spawner;
    private int trashNum;

    private Dictionary<Trash, int> correctTrash = new(); // �и����� ������ �������
    private Dictionary<Trash, int> incorrectTrash = new(); // �и����� ������ �������

    public Transform correctContent;
    public Transform incorrectContent;
    public TMP_Text correctText;
    public TMP_Text incorrectText;
    public SeparateResultTrashButton separateResultTrashButton;

    void Awake()
    {
        base.Awake();
        SaveManager.OnLoad.AddListener(GameStart);
    }
    
    private void GameStart(SaveFile saveFile)
    {
        trashNum = saveFile.GetTrashNum();
        
        if(trashNum == 0)
        {
            UIManager.Instance.ActiveSeparateGameEnd(true);
        }
        else
        {
            UIManager.Instance.ActiveSeparateGameEnd(false);
            spawner.SpawnStart(saveFile);
        }
    }

    public void Emission()
    {
        trashNum--;

        if(trashNum == 0)
        {
            EmissionResultUpdate();
            OnEnd.Invoke();
        }
    }

    public void CorrectTrash(Trash trash)
    {
        if (correctTrash.ContainsKey(trash))
            correctTrash[trash]++;
        else
            correctTrash.Add(trash, 1);
    }

    public void IncorrectTrash(Trash trash)
    {
        if (incorrectTrash.ContainsKey(trash))
            incorrectTrash[trash]++;
        else
            incorrectTrash.Add(trash, 1);
    }

    // �и� ������ ���� ��� ����
    public void EmissionResultUpdate()
    {
        correctText.text = $"���� : {correctTrash.Values.Sum()}";
        incorrectText.text = $"���� : {incorrectTrash.Values.Sum()}";

        // correct trash
        foreach (var resultInfo in correctTrash)
        {
            SeparateResultTrashButton sr = Instantiate(separateResultTrashButton, correctContent);
            sr.Init(resultInfo.Key, resultInfo.Value);
        }

        // incorrect trash
        foreach (var resultInfo in incorrectTrash)
        {
            SeparateResultTrashButton sr = Instantiate(separateResultTrashButton, incorrectContent);
            sr.Init(resultInfo.Key, resultInfo.Value);
        }
    }
}
