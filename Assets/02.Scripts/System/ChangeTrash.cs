using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTrash : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D coll;
    public TrashType type;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        Change();
    }

    public void Change()
    {
        Trash t = TrashManager.Instance.GetRandomTrash();
        type = t.type;
        spriteRenderer.sprite = t.sprite;
        coll.offset = t.coll.offset;
        coll.size = t.coll.size;
        print(t.name);
    }
}
