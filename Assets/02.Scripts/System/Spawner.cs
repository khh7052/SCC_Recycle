using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject spawnObject;
    public float spawnRate = 5f;

    private void Awake()
    {
        SaveManager.OnLoad.AddListener(SpawnStart);
    }

    void SpawnStart(SaveFile saveFile)
    {

        StartCoroutine(Spawn(saveFile));
    }

    IEnumerator Spawn(SaveFile saveFile)
    {
        WaitForSeconds wait = new(spawnRate);

        List<Trash> trashList = saveFile.GetTrashList();

        foreach (var trash in trashList)
        {
            print(trash.trashName);

            
            GameObject trashObject = PoolManager.Instance.Pop(spawnObject, spawnPoint.position, Quaternion.identity);
            trashObject.GetComponent<TrashObject>().ChangeTrash(trash);

            yield return wait;
        }

        print("end");
    }

}
