using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour
{
    public bool onRandom = true;
    private SpriteRenderer spriteRenderer;
    private Collider2D coll;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

    private void Start()
    {
        ChangeRandomTrash();
    }

    public void ChangeTrash(Trash trash)
    {
        spriteRenderer.sprite = trash.sprite;
        name = trash.trashName;
        coll.CreateMesh(true, true);
    }

    public void ChangeRandomTrash()
    {
        if (!onRandom) return;
        Trash trash = TrashManager.Instance.GetRandomTrash();
        ChangeTrash(trash);
    }

}
