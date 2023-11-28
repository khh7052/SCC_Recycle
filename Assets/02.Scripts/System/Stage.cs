using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Stage")]
public class Stage : ScriptableObject
{
    public Sprite groundSprite;
    public Sprite skySprite;
    public GameObject[] obstacles; // ��ֹ���
    public GameObject[] patterns; // ���ϵ�
    public float stageTime = 30f; // �������� �ð�
    public float obstacleSpawnDelay = 5f; // ��ֹ� ���� ����
    public float patternSpawnDelay = 5f; // ��ֹ� ���� ����

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
