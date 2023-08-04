using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D coll;

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
        spriteRenderer.sprite = t.sprite;
        coll.offset = t.coll.offset;
        coll.size = t.coll.size;
    }
}
