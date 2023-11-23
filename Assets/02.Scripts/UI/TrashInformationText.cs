using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum TrashInformationTextType
{
    NAME,
    TYPE,
    THROW,
    INFORMATION
}

public class TrashInformationText : MonoBehaviour
{
    public TrashInformationTextType type;

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
            case TrashInformationTextType.NAME:
                text.text = trash.trashRealName;
                break;
            case TrashInformationTextType.TYPE:
                text.text = trash.Type.ToString();
                break;
            case TrashInformationTextType.THROW:
                text.text = trash.description_throw;
                break;
            case TrashInformationTextType.INFORMATION:
                text.text = trash.description_information;
                break;
        }
    }

}
