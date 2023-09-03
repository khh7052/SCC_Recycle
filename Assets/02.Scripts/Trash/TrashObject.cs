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
        SettingUpdate();
    }

    void SettingUpdate()
    {
        TrashObjectSetting setting = TrashManager.TrashObjectSetting[SceneManager.GetActiveScene().name];

        if(rigd != null)
        {
            rigd.bodyType = setting.rigdType;
            rigd.gravityScale = setting.gravity;
        }

        if(coll != null) coll.isTrigger = setting.isTrigger;
        if(dragObject != null) dragObject.enabled = setting.onDrag;
    }

}
