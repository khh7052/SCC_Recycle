using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : Singleton<TalkManager>
{
    // NPC�� � ��簡 ������ ����
    //TalkInteraction �ʿ�
    public Dictionary<int, string[]> talkData;
    void Start()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        System.DateTime.Now.ToString("yyyy");
        talkData.Add(0, new string[] { DateTime.Now.ToString("yyyyMMdd"), "�ȳ��ϼ���!", "123123" } );


        talkData.Add(1000, new string[] { DateTime.Now.ToString("yyyyMMdd") } );
        talkData.Add(1001, new string[] { "����� ����ƺ�..." });

    }

    public string Gettalk(int id, int talkIndex)
    {
        if(talkIndex == talkData[id].Length)
        { return null; }
        else
        return talkData[id][talkIndex];
    }
}
