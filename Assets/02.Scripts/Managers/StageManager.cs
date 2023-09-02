using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    public Transform spawnParent;
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

        while (true)
        {
            GameObject pattern = CurrentStage.GetRandomPattern();

            for(int i = 0; i < pattern.transform.childCount; i++)
            {
                Transform child = pattern.transform.GetChild(i);
                PoolManager.Instance.Pop(child.gameObject, child.position, child.rotation).transform.SetParent(spawnParent);
            }
            
            yield return wait;
        }
    }
    
}
