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
    public string trashSaveName; // ����, ���� �ҷ����⿡�� ���Ǵ� �̸�
    public string trashRealName; // UI ǥ�ÿ��� ���Ǵ� �̸�
    
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
