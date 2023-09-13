using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CostData
{
    public TrashType trashType;
    public int cost;
}

[CreateAssetMenu(menuName ="Create Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public string itemName;
    public string description;
    public CostData[] costDatas;
}
