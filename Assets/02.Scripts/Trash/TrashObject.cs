using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[System.Serializable]
public struct TrashObjectSetting
{
    public string sceneName;
    public RigidbodyType2D rigdType;
    public float gravity;
    public bool isTrigger;
    public bool onDrag;
    public bool onMouseAnim;
    public bool onChild;
}

public class TrashObject : MonoBehaviour
{
    public UnityEvent OnEndEquip = new();

    public Trash trash;
    private Rigidbody2D rigd;
    private Collider2D coll;
    private DragObject dragObject;
    private Animator animator;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        dragObject = GetComponent<DragObject>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        NameUpdate();
    }

    private void OnEnable()
    {
        
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
        if(dragObject != null)
        {
            dragObject.OnDrag = setting.onDrag;
            dragObject.OnMouseAnim = setting.onMouseAnim;
        }

        if (!setting.onChild)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void StartEquip(string equipSFXName)
    {
        Debug.Log("StartEquipe");
        coll.enabled = false;
        rigd.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Equip");
    }

    public void EndEquip()
    {
        if(SceneManager.GetActiveScene().name == "Play")
            TrashManager.Instance.AddTrash(trash.trashSaveName);

        gameObject.SetActive(false);
        coll.enabled = true;
        //SoundManager.Instance.PlaySFX("Equip");

        animator.SetBool("Equip", false);
        OnEndEquip.Invoke();
    }

    private void OnMouseEnter()
    {
        if (!enabled) return;

        UIManager.Instance.ActiveTrashSimpleInformation(true);
        UIManager.Instance.TrashSimpleInformationUpdate(trash);
    }

    private void OnMouseExit()
    {
        if (!enabled) return;

        UIManager.Instance.ActiveTrashSimpleInformation(false);
    }

}
