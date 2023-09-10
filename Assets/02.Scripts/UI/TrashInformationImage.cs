using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashInformationImage : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }


    public void ImageUpdate(Trash trash)
    {
        if (trash == null) return;
        if(image == null) return;

        image.sprite = trash.trashTypeInformation.typeSprite;
    }

}
