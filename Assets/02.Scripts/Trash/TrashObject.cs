using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour
{
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

    public void ChangeRandomTrash()
    {
        Trash trash = TrashManager.Instance.GetRandomTrash();
        spriteRenderer.sprite = trash.sprite;
        name = trash.trashName;
        coll.CreateMesh(true, true);
    }

}
