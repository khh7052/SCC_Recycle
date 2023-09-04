using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllTrashNumText : MonoBehaviour
{
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public void TextUpdate()
    {
        if (text == null) return;

        text.text = SaveManager.SaveFile.GetTrashNum().ToString();
    }

}
