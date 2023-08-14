using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Stage")]
public class Stage : ScriptableObject
{
    public Sprite groundSprite;
    public Sprite skySprite;
    public GameObject[] patterns;
    public float stageTime = 30f; // 스테이지 시간
}
