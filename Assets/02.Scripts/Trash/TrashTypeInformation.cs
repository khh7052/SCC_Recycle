using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Create TrashTypeInformation")]
public class TrashTypeInformation : ScriptableObject
{
    public string typeName;
    public TrashType originalType;
    public TrashType integrateType;
    public Sprite typeSprite;
    public string description;
}
