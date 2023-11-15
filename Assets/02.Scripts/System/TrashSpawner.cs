using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum SpawnerType
{
    SECOND,
    UNTIL
}

public class TrashSpawner : MonoBehaviour
{
    public UnityEvent OnSpawnStart;
    public UnityEvent<Trash, GameObject> OnSpawn;
    public UnityEvent OnSpawnEnd;

    public SpawnerType type;
    public Transform spawnPoint;
    public float spawnRate = 5f;
    private bool onSpawn = false;

    private int restSpawnCount = -1; // 남은 스폰 수
    public int RestSpawnCount
    {
        get { return restSpawnCount; }
    }

    private Coroutine spawnCoroutine;

    private void OnDisable()
    {
        SpawnStop();
    }

    public void OnSpawnToggle()
    {
        onSpawn = !onSpawn;
    }

    public void SpawnStart(SaveFile saveFile)
    {
        spawnCoroutine = StartCoroutine(Spawn(saveFile));
    }

    void SpawnStop()
    {
        if (spawnCoroutine == null) return;

        StopCoroutine(spawnCoroutine);
    }

    IEnumerator Spawn(SaveFile saveFile)
    {
        WaitForSeconds wait = new(spawnRate);
        WaitUntil until = new(() => onSpawn);

        List<Trash> trashList = saveFile.GetRandomTrashList();
        restSpawnCount = trashList.Count;
        print(restSpawnCount);
        
        OnSpawnStart.Invoke();

        foreach (var trash in trashList)
        {
            GameObject spawnObject = TrashManager.Instance.GetTrashInform(trash.trashSaveName).trashObject;
            GameObject t = PoolManager.Instance.Pop(spawnObject, spawnPoint.position, Quaternion.identity);
            restSpawnCount--;

            OnSpawn.Invoke(trash, t);

            switch (type)
            {
                case SpawnerType.SECOND:
                    yield return wait;
                    break;
                case SpawnerType.UNTIL:
                    yield return until;
                    onSpawn = false;
                    break;
            }
        }

        OnSpawnEnd.Invoke();
    }

}
