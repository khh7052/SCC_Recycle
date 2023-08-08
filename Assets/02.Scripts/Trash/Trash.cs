using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrashType
{
    CAN,
    PLASTIC,
    PAPER
}

public class Trash : MonoBehaviour
{
    public Sprite sprite;
    public BoxCollider2D coll;
    public string trashName;
    public string description;
    public int num;
    public TrashType type;
}
