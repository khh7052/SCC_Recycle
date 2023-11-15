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
        print(num + " !!");
    }
    
    public void TextDecrease()
    {
        if (text == null) return;
        num--;
        print(num + " !! " + gameObject.name);
        text.text = num.ToString();
    }

}
