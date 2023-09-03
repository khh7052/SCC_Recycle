using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrashType
{
    CAN,
    PLASTIC,
    PAPER,
    GLASS,
    LENGTH
}

[CreateAssetMenu(menuName = "Create Trash")]
public class Trash : ScriptableObject
{
    public Sprite sprite;
    public string trashName;
    [TextArea(3, 10)]
    public string description;
    public TrashType type;
    public GameObject trashObject;
}
