using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SperateEmissionManager : MonoBehaviour
{
    public int currentCount;
    public int maxCount;

    private void Awake()
    {
        SaveManager.OnLoad.AddListener(GameStart);
    }

    public void GameStart(SaveFile saveFile)
    {
        maxCount = saveFile.GetTrashNum();
    }

}
