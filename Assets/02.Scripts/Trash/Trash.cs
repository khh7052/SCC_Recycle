using System.Collections;
using System.Collections.Generic;
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

[CreateAssetMenu(menuName = "Create Trash")]
public class Trash : ScriptableObject
{
    public Sprite sprite;
    public string trashSaveName; // 저장, 정보 불러오기에서 사용되는 이름
    public string trashRealName; // UI 표시에서 사용되는 이름
    
    [TextArea(3, 10)]
    public string description_throw;

    [TextArea(3, 10)]
    public string description_information;

    public GameObject trashObject;
    public RecycleActType recycleActType;
    public TrashTypeInformation trashTypeInformation;

    public TrashType Type
    {
        get { return trashTypeInformation.originalType; }
    }

}
