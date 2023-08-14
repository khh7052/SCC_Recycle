using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StageManager : MonoBehaviour
{
    public Stage[] stages;
    private int stageIndex;

    public Stage CurrentStage
    {
        get
        {
            return stages[stageIndex];
        }
    }

    private void Update()
    {
        if(Time.time > CurrentStage.stageTime)
        {
            stageIndex = Mathf.Max(stageIndex++, stages.Length-1);
        }
    }


}
