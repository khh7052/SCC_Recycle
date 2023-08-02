using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColorSetting : MonoBehaviour
{
    public Transform[] targets;
    public Color settingColor;
    public float settingSize = 1;

    

    public void ColorSetting()
    {
        foreach (Transform target in targets)
        {
            foreach (SpriteRenderer spriteRenderer in target.GetComponentsInChildren<SpriteRenderer>())
            {
                spriteRenderer.color = settingColor;
            }
        }
    }

    public void SizeSetting()
    {
        Vector3 size = Vector3.one * settingSize;
        foreach (Transform target in targets)
        {
            foreach (Transform child in target.GetComponentsInChildren<Transform>())
            {
                target.localScale = size;
            }
        }
    }
}
