using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInformationBuilder : MonoBehaviour
{
    public Transform content;
    public SeparateResultTrashButton trashButton;
    public TrashManager trashManager;

    private void Start()
    {
        TrashInformaitonUpdate();
    }

    [ContextMenu("Update Information")]
    public void TrashInformaitonUpdate()
    {
        if (content == null) return;
        if (trashButton == null) return;
        if (trashManager == null) return;

        for (int i = content.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(content.GetChild(i).gameObject);
        }
        
        // incorrect trash
        foreach (var trash in trashManager.trashes)
        {
            SeparateResultTrashButton sr = Instantiate(trashButton, content);
            sr.Init(trash, 0);
        }
    }
}
