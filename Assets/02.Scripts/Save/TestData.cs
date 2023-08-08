using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataC
{
    public TrashType type;
    public int num;

    public DataC()
    {
        type = TrashType.PLASTIC;
        num = 2;
    }

    public DataC(TrashType type, int num)
    {
        this.type = type;
        this.num = num;
    }
}

public class TestData
{
    public DataC[] dataCs;
}
