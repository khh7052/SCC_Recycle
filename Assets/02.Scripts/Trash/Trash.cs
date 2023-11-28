using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public enum TrashType
{
    CAN,
    CAN_ALUMINUM,
    CAN_METAL,
    CAN_END,
    PLASTIC,
    PLASTIC_HDPE,
    PLASTIC_LDPE,
    PLASTIC_OTHER,
    PLASTIC_PP,
    PLASTIC_PS,
    PLASTIC_PET,
    PLASTIC_END,
    PET,
    PACK,
    VINYL,
    VINYL_HDPE,
    VINYL_LDPE,
    VINYL_OTHER,
    VINYL_PP,
    VINYL_PS,
    VINYL_PET,
    VINYL_END,
    PAPER,
    GLASS,
    COMMON,
    LENGTH
}

[Flags]
public enum RecycleActType
{
    NONE = 0,
    CLEAR = 1 << 0,
    RINSE = 1 << 1,
    DETACH = 1 << 2,
    END = 1 << 3,
}

[CreateAssetMenu(menuName = "Create Trash")]
public class Trash : ScriptableObject
{
    public Sprite sprite;
    public string trashSaveName; // 저장, 정보 불러오기에서 사용되는 이름
    public string trashRealName; // UI 표시에서 사용되는 이름
    
    [TextArea(3, 10)]
    public string description_throw;

    public GameObject trashObject;
    public RecycleActType recycleActType;
    public TrashTypeInformation trashTypeInformation;

    public TrashType Type
    {
        get { return trashTypeInformation.originalType; }
    }


    public string GetActTypeText()
    {
        string s = "";
        if (recycleActType == RecycleActType.NONE)
        {
            s = "없음";
        }
        else
        {
            if((recycleActType & RecycleActType.CLEAR) != 0) s += "비우기 ";
            if ((recycleActType & RecycleActType.RINSE) != 0) s += "헹구기 ";
            if ((recycleActType & RecycleActType.DETACH) != 0) s += "분리하기 ";
        }

        s = s.Trim();
        s = s.Replace(" ", ", ");

        return s;
    }

}
