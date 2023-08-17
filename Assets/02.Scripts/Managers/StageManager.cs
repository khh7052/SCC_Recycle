using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    public Stage[] stages;
    private int stageIndex;
    private float time = 0f;

    public Stage CurrentStage
    {
        get
        {
            return stages[stageIndex];
        }
    }

    private void Start()
    {
        StartCoroutine(CreatePattern());
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time > CurrentStage.stageTime)
        {
            time = 0f;
            NextStage();
        }
    }


    void NextStage()
    {
        stageIndex = Mathf.Min(stageIndex + 1, stages.Length - 1);
        print("NextStage");
    }

    public void PatternUpdate()
    {

    }

    IEnumerator CreatePattern()
    {
        WaitForSeconds wait = new(5f);
        Vector2 spawnPos = new(24f, 0f);

        while (true)
        {
            PoolManager.Instance.Pop(CurrentStage.GetRandomPattern());
            yield return wait;
        }
    }
    
}
