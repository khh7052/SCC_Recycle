using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum TrashInformationType
{
    NAME,
    TYPE,
    DESCRIPTION
}

public class TrashInformationText : MonoBehaviour
{
    public TrashInformationType type;

    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public void TextUpdate(Trash trash)
    {
        switch (type)
        {
            case TrashInformationType.NAME:
                text.text = trash.trashName;
                break;
            case TrashInformationType.TYPE:
                text.text = trash.type.ToString();
                break;
            case TrashInformationType.DESCRIPTION:
                text.text = trash.description;
                break;
        }
    }

}
