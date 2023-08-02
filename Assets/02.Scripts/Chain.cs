using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    SpriteRenderer sprite;
    public Transform target;


    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ChainUpdate();
    }

    void ChainUpdate()
    {
        Vector2 size = sprite.size;
        size.y = (transform.position.y - target.position.y) / transform.lossyScale.y;
        sprite.size = size;
    }
}
