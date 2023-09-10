using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create TrashTypeInformation")]
public class TrashTypeInformation : ScriptableObject
{
    public string typeName;
    public TrashType trashType;
    public Sprite typeSprite;
    public string description;
}
