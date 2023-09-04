using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SperateEmissionManager : Singleton<SperateEmissionManager>
{
    public TrashSpawner spawner;
    private int num = 0;

    public override void Awake()
    {
        base.Awake();
        SaveManager.OnLoad.AddListener(GameStart);
    }

    public void GameStart(SaveFile saveFile)
    {
        int trashNum = saveFile.GetTrashNum();

        if(trashNum == 0)
        {
            UIManager.Instance.ActiveSperateError(true);
        }
        else
        {
            UIManager.Instance.ActiveSperateError(false);
            spawner.SpawnStart(saveFile);
        }
    }

    public void TrashNumCheck()
    {
        if (SaveManager.SaveFile.GetTrashNum() == 0)
        {
            UIManager.Instance.ActiveSperateGameEnd(true);
        }
    }

    public void SperateEmissionEndCheck()
    {
        if (num == 0)
        {
            UIManager.Instance.ActiveSperateGameEnd(true);
        }
        else
        {
            spawner.OnSpawnToggle();
        }
    }

    public void TrashNumPlus()
    {
        num++;
    }

    public void TrashNumMinus()
    {
        num--;
    }


}
