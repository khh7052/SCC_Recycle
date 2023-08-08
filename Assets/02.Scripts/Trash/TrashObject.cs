using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D coll;
    private TrashType type;

    public TrashType Type
    {
        get { return type; }
        set
        {
            type = value;

        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        ChangeRandomTrash();
    }

    public void ChangeRandomTrash()
    {
        Trash t = TrashManager.Instance.GetRandomTrash();
        type = t.type;
        spriteRenderer.sprite = t.sprite;
        coll.offset = t.coll.offset;
        coll.size = t.coll.size;
    }

}
