using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SperateEmissionManager : MonoBehaviour
{
    private void Awake()
    {
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
        }
    }

}
