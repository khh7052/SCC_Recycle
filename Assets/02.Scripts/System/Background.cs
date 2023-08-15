using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public enum BackgroundType
    {
        GROUND,
        SKY
    }

    public BackgroundType bakcgroundType;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void SpriteUpdate()
    {
        print("!!#!#!#");
        Stage stage = StageManager.Instance.CurrentStage;

        switch (bakcgroundType)
        {
            case BackgroundType.GROUND:
                spriteRenderer.sprite = stage.groundSprite;
                break;
            case BackgroundType.SKY:
                spriteRenderer.sprite = stage.skySprite;
                break;
            default:
                break;
        }
    }
}
