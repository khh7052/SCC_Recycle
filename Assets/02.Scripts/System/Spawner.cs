using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public UnityEvent OnSpawnEnd;

    public Transform spawnPoint;
    public float spawnRate = 5f;

    private Coroutine spawnCoroutine;

    private void Awake()
    {
        SaveManager.OnLoad.AddListener(SpawnStart);
    }

    private void OnDisable()
    {
        SpawnStop();
    }


    void SpawnStart(SaveFile saveFile)
    {
        UIManager.Instance.CurrentTrashNumTextUpdate();
        spawnCoroutine = StartCoroutine(Spawn(saveFile));
    }

    void SpawnStop()
    {
        StopCoroutine(spawnCoroutine);
    }

    IEnumerator Spawn(SaveFile saveFile)
    {
        WaitForSeconds wait = new(spawnRate);

        List<Trash> trashList = saveFile.GetRandomTrashList();

        foreach (var trash in trashList)
        {
            print(trash.trashName);

            GameObject spawnObject = TrashManager.Instance.GetTrashInform(trash.trashName).trashObject;
            GameObject t = PoolManager.Instance.Pop(spawnObject, spawnPoint.position, Quaternion.identity);
            t.name = trash.trashName;

            yield return wait;
        }

        OnSpawnEnd.Invoke();
    }

}
