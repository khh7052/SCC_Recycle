using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashRecordText : MonoBehaviour
{
    public TrashCan trashCan;
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }
    private void OnEnable()
    {
        TextUpdate();
    }

    void TextUpdate()
    {
        if (text == null) return;

        text.text = trashCan.TrashCount.ToString();
    }

}
