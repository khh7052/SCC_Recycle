using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActButton : MonoBehaviour
{
    public RecycleActType actType;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Init()
    {
        SeparateManager.Instance.currentActType = 0;
        image.color = Color.white;
    }

    public void OnActButton()
    {
        image.color = image.color == Color.white ? Color.black : Color.white;
        
        if ((SeparateManager.Instance.currentActType & actType) == 0) // 버튼의 행동이 활성화 안되어있으면
        {
            SeparateManager.Instance.currentActType |= actType; // 행동 추가
        }
        else
        {
            SeparateManager.Instance.currentActType &= ~actType; // 행동 제거
        }
        
    }
}
