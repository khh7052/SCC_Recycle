using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeperateEmissionManager : Singleton<SeperateEmissionManager>
{
    public TrashSpawner spawner;
    private int trashNum = 0;
    public RecycleActType currentActType;
    private Trash currentTrash;

    public override void Awake()
    {
        base.Awake();
        SaveManager.OnLoad.AddListener(GameStart);
    }

    public void GameStart(SaveFile saveFile)
    {
        trashNum = saveFile.GetTrashNum();

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

    public void TrashUpdate(Trash trash, GameObject trashObject)
    {
        trashNum = trashObject.GetComponentsInChildren<TrashObject>().Length;
        print(trashNum);
    }
    public void WasteTrash()
    {
        trashNum--;
    }
    
    public void TrashNumCheck()
    {
        if (SaveManager.SaveFile.GetTrashNum() == 0)
        {
            UIManager.Instance.ActiveSperateGameEnd(true);
        }
    }

    public void SuccessCheck()
    {
        // 모든 처리작업 완료했는지
        if (trashNum == 0)
        {
            // 모든 쓰레기 생성했는지
            if (spawner.RestSpawnCount == 0)
            {
                UIManager.Instance.ActiveSperateGameEnd(true);
            }
            else
            {
                spawner.OnSpawnToggle();
            }
        }
        else
        {
            UIManager.Instance.ErrorTextUpdate("아직 쓰레기가 남아있습니다.");
        }
    }
}
