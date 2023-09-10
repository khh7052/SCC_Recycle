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
    public string trashSaveName; // 저장, 정보 불러오기에서 사용되는 이름
    public string trashRealName; // UI 표시에서 사용되는 이름
    
    [TextArea(3, 10)]
    public string description;
    [TextArea(3, 10)]
    public string seperateErrorMessage;

    // public TrashType type;
    public GameObject trashObject;
    public TrashTypeInformation trashTypeInformation;

    public TrashType Type
    {
        get { return trashTypeInformation.trashType; }
    }

}
