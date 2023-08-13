using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Create Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public string itemName;
    public string description;
    public int point;
}
