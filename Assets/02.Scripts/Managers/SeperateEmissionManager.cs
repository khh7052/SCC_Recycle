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
        // ��� ó���۾� �Ϸ��ߴ���
        if (trashNum == 0)
        {
            // ��� ������ �����ߴ���
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
            UIManager.Instance.ErrorTextUpdate("���� �����Ⱑ �����ֽ��ϴ�.");
        }
    }


    // 1. �����⸦ ������
    // 2. �����⸦ ������� ��Ȱ����
    // 3. �������� ��� �κ��� ������� ó���ߴ��� Ȯ��
    // 4. �����⸦

    // ��(������ �и���), �۰�(��ź���� ���������)
    // ��ũ��(�󱼶� �ʿ�), ��(�и��� ������ ��ƵѰ�)

}
