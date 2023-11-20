using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TrashInformationImageType
{
    SPRITE,
    TYPE,
}

public class TrashInformationImage : MonoBehaviour
{
    public TrashInformationImageType type;
    
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }


    public void ImageUpdate(Trash trash)
    {
        if (trash == null) return;
        if(image == null) return;

        switch (type)
        {
            case TrashInformationImageType.SPRITE:
                image.sprite = trash.sprite;
                break;
            case TrashInformationImageType.TYPE:
                image.sprite = trash.trashTypeInformation.typeSprite;
                break;
        }
    }

}
