using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Change();
    }

    public void Change()
    {
        int rand = Random.Range(0,sprites.Length);
        spriteRenderer.sprite = sprites[rand];
    }
}
