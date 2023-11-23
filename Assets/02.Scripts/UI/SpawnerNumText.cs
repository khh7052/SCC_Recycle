using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerNumText : MonoBehaviour
{
    public TrashSpawner spawner;
    private TMP_Text text;
    private int num;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }
    
    public void TextInit()
    {
        if (text == null) return;
        num = spawner.RestSpawnCount;
        text.text = num.ToString();
    }
    
    public void TextDecrease()
    {
        if (text == null) return;
        num--;
        text.text = num.ToString();
    }

}
