using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum TrashInformationType
{
    NAME,
    TYPE,
    DESCRIPTION,
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
        if (text == null) return;
        if (trash == null) return;

        switch (type)
        {
            case TrashInformationType.NAME:
                text.text = trash.trashRealName;
                break;
            case TrashInformationType.TYPE:
                text.text = trash.Type.ToString();
                break;
            case TrashInformationType.DESCRIPTION:
                text.text = trash.description;
                break;
        }
    }

}
