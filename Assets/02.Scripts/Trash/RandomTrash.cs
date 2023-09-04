using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTrash : MonoBehaviour
{
    private void OnEnable()
    {
        SpawnRandomTrash();
    }

    public void SpawnRandomTrash()
    {
        Trash trash = TrashManager.Instance.GetRandomTrash();
        GameObject trashObject = PoolManager.Instance.Pop(trash.trashObject, transform.position, transform.rotation);
        trashObject.transform.SetParent(StageManager.Instance.spawnParent, true);
    }

}
