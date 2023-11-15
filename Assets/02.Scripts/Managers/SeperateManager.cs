using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeperateInformation
{
    public Trash trash;
    public RecycleActType selectedActType; // 플레이어가 선택한 행동
}

public class SeperateManager : Singleton<SeperateManager>
{
    public TrashSpawner spawner;
    public RecycleActType currentActType;
    private Trash currentTrash;
    private GameObject currentTrashObject;

    private Dictionary<Trash, int> correctTrash; // 분리수거 성공한 쓰레기들
    private Dictionary<Trash, int> incorrectTrash; // 분리수거 실패한 쓰레기들

    private ActButton[] actButtons;

    public override void Awake()
    {
        base.Awake();
        actButtons = FindObjectsOfType<ActButton>();
        SaveManager.OnLoad.AddListener(GameStart);
    }

    public void GameStart(SaveFile saveFile)
    {
        if(saveFile.GetTrashNum() == 0)
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
        currentTrash = trash;
        currentTrashObject = trashObject;

        foreach (var actButton in actButtons)
        {
            actButton.Init();
        }
    }

    public void SuccessCheck()
    {
        // 쓰레기에 필요한 행동과 똑같은지 비교
        if (currentActType == currentTrash.recycleActType)
        {
            // 쓰레기 스폰
            UIManager.Instance.ErrorTextUpdate("정답!");

            if (correctTrash.ContainsKey(currentTrash))
            {
                correctTrash[currentTrash]++;
            }
            else
            {
                correctTrash.Add(currentTrash, 1);
            }
        }
        // 다를 때
        else
        {
            UIManager.Instance.ErrorTextUpdate("오답!");
            
            if (incorrectTrash.ContainsKey(currentTrash))
            {
                incorrectTrash[currentTrash]++;
            }
            else
            {
                incorrectTrash.Add(currentTrash, 1);
            }
            
            /*
            // 필요한 행동이 많을 때
            if (currentActType > currentTrash.recycleActType)
            {
                UIManager.Instance.ErrorTextUpdate("불필요한 행동이 존재합니다!");
            }
            // 필요한 행동이 부족할 때
            else
            {
                UIManager.Instance.ErrorTextUpdate("필요한 작업이 부족합니다!");
            }
            */
        }
        
        currentTrashObject.gameObject.SetActive(false);
        spawner.OnSpawnToggle();
        
        /*
        
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
        */
    }
}
