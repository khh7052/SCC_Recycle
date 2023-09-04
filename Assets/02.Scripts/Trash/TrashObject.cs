using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct TrashObjectSetting
{
    public string sceneName;
    public RigidbodyType2D rigdType;
    public float gravity;
    public bool isTrigger;
    public bool onDrag;
}

public class TrashObject : MonoBehaviour
{
    public Trash trash;
    private Rigidbody2D rigd;
    private Collider2D coll;
    private DragObject dragObject;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        dragObject = GetComponent<DragObject>();
    }

    private void OnEnable()
    {
        NameUpdate();
        SettingUpdate();
    }

    void NameUpdate()
    {
        if (trash == null) return;

        name = trash.trashSaveName;
    }

    void SettingUpdate()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (!TrashManager.TrashObjectSetting.ContainsKey(sceneName)) TrashManager.Instance.TrashSettingInit();
        if (!TrashManager.TrashObjectSetting.ContainsKey(sceneName)) return;

        TrashObjectSetting setting = TrashManager.TrashObjectSetting[sceneName];

        if(rigd != null)
        {
            rigd.bodyType = setting.rigdType;
            rigd.gravityScale = setting.gravity;
        }

        if(coll != null) coll.isTrigger = setting.isTrigger;
        if(dragObject != null) dragObject.enabled = setting.onDrag;
    }

    private void OnMouseEnter()
    {
        if (!enabled) return;

        UIManager.Instance.ActiveTrashInformation(true);
        UIManager.Instance.TrashInformationUpdate(trash);
    }

    private void OnMouseExit()
    {
        if (!enabled) return;

        UIManager.Instance.ActiveTrashInformation(false);
    }

    private void OnMouseDown()
    {
        
    }

}
