using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EmissionManager : Singleton<EmissionManager>
{
    public TrashSpawner spawner;
    private int trashNum;

    public UnityEvent OnEnd;

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
        if (trashNum == 0)
        {
            OnEnd.Invoke();
        }
    }
}
