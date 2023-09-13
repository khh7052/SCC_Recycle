using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeImage : MonoBehaviour
{
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void ImageUpdate(TrashType type)
    {
        if (TrashManager.Instance == null) return;
        if (image == null) return;

        TrashTypeInformation typeInformation = TrashManager.Instance.GetTrashTypeInform(type);
        if (typeInformation == null) return;

        image.sprite = typeInformation.typeSprite;
    }
}
