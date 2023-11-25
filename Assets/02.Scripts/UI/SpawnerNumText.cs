using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerNumText : MonoBehaviour
{
    private TrashSpawner spawner;
    private TMP_Text text;
    private int num;

    private void Awake()
    {
        spawner = FindObjectOfType<TrashSpawner>();
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
