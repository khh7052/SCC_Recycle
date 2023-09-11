using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeperateEmissionManager : Singleton<SeperateEmissionManager>
{
    public TrashSpawner spawner;
    private int trashNum = 0;

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

    public void TrashCheck()
    {

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


    // 1. 쓰레기를 생성함
    // 2. 쓰레기를 절차대로 재활용함
    // 3. 쓰레기의 모든 부분을 절차대로 처리했는지 확인
    // 4. 쓰레기를

    // 손(쓰레기 분리용), 송곳(부탄가스 가스빼기용)
    // 싱크대(헹굴때 필요), 통(분리한 쓰레기 담아둘곳)

}
