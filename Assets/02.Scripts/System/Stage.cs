using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Stage")]
public class Stage : ScriptableObject
{
    public Sprite groundSprite;
    public Sprite skySprite;
    public GameObject[] obstacles; // 장애물들
    public GameObject[] patterns; // 패턴들
    public float stageTime = 30f; // 스테이지 시간
    public float obstacleSpawnDelay = 5f; // 장애물 생성 간격
    public float patternSpawnDelay = 5f; // 장애물 생성 간격

    public GameObject GetRandomObstacle()
    {
        if (obstacles.Length == 0) return null;

        int rand = Random.Range(0, obstacles.Length);
        return obstacles[rand];
    }

    public GameObject GetRandomPattern()
    {
        if (patterns.Length == 0) return null;

        int rand = Random.Range(0, patterns.Length);
        return patterns[rand];
    }
}
