using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashTypeImage : MonoBehaviour
{
    public TrashType trashType;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        ImageUpdate();
    }

    void ImageUpdate()
    {
        image.sprite = TrashManager.Instance.GetTrashTypeInform(trashType).typeSprite;
    }
}
