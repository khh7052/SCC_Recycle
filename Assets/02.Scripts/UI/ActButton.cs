using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActButton : MonoBehaviour
{
    public RecycleActType actType;
    private Image image;
    public Color pressedColor;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Init()
    {
        SeparateManager.Instance.currentActType = RecycleActType.NONE;
        image.color = Color.white;
    }

    public void OnActButton()
    {
        image.color = image.color == Color.white ? pressedColor : Color.white;
        
        if ((SeparateManager.Instance.currentActType & actType) == RecycleActType.NONE) // 버튼의 행동이 활성화 안되어있으면
        {
            SeparateManager.Instance.currentActType |= actType; // 행동 추가
        }
        else
        {
            SeparateManager.Instance.currentActType &= ~actType; // 행동 제거
        }
        
    }
}
