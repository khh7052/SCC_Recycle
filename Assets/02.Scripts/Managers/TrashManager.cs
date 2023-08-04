using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : Singleton<TrashManager>
{
    public Trash[] trashes;

    public Trash GetRandomTrash()
    {
        return trashes[Random.Range(0, trashes.Length)];
    }
}
