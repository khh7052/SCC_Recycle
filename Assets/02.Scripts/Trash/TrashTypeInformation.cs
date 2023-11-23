using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Flags]
public enum RecycleActType
{
    NONE = 0,
    CLEAR = 1 << 0,
    RINSE = 1 << 1,
    DETACH = 1 << 2,
}

[CreateAssetMenu(menuName = "Create TrashTypeInformation")]
public class TrashTypeInformation : ScriptableObject
{
    public string typeName;
    public TrashType originalType;
    public TrashType integrateType;
    public Sprite typeSprite;
    public string description;
    
}
