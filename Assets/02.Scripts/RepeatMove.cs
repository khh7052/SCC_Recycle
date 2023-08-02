using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatMove : MonoBehaviour
{
    private List<Transform> onPlatformObjects;

    public Vector2[] localWaypoints;
    private Vector2[] globalWaypoints;

    public float moveSpeed = 5f;
    public float waitTime = 1f;
    private float nextMoveTime;

    private int currentIndex;
    private int targetIndex;
    
    public bool cycle = false; // true : targetIndex�� �ٽ� 0���� ������
    private int direction = 1;

    void Awake()
    {
        Init();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Init()
    {
        globalWaypoints = localWaypoints;

        for (int i = 0; i < globalWaypoints.Length; i++)
        {
            globalWaypoints[i] += (Vector2)transform.position;
        }

        currentIndex = 0;
        targetIndex = currentIndex + direction;
        nextMoveTime = 0;

        onPlatformObjects = new List<Transform>();
    }

    void NextIndexUpdate()
    {
        currentIndex += direction;
        targetIndex += direction;
        // Ÿ�� �ε��� ����
        // Ÿ�� �ε����� �������� ����� �ΰ��� �߿� ����
        // 1. �ε��� ������ �ݴ�������� �ٲ��, current���� �׹������� ������
        // 2. �ƴϸ� �ٽ� 0���� ������

        if (cycle)
        {
            currentIndex %= localWaypoints.Length;
            targetIndex %= localWaypoints.Length;
        }
        else
        {
            if (targetIndex >= localWaypoints.Length || targetIndex < 0)
            {
                direction *= -1;
                targetIndex = currentIndex + direction;
            }
        }
    }

    void NextMoveTimeUpdate()
    {
        nextMoveTime = Time.time + waitTime;
    }

    void Move()
    {
        if (localWaypoints.Length <= 1) return;
        if (nextMoveTime > Time.time) return;

        Vector2 prePos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, localWaypoints[targetIndex], moveSpeed * Time.fixedDeltaTime);

        Vector2 moveAmount = (Vector2)transform.position - prePos;

        foreach (Transform t in onPlatformObjects)
        {
            t.Translate(moveAmount);
        }

        if ((Vector2)transform.position == localWaypoints[targetIndex])
        {
            NextIndexUpdate();
            NextMoveTimeUpdate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody && collision.attachedRigidbody.bodyType == RigidbodyType2D.Dynamic)
        {
            if (onPlatformObjects.Contains(collision.transform)) return;
            onPlatformObjects.Add(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody && collision.attachedRigidbody.bodyType == RigidbodyType2D.Dynamic)
        {
            if (onPlatformObjects.Contains(collision.transform) == false) return;
            onPlatformObjects.Remove(collision.transform);
        }
    }



    private void OnDrawGizmos()
    {
        if (localWaypoints == null) return;

        Gizmos.color = Color.yellow;
        if (Application.isPlaying)
        {
            foreach (var waypoints in globalWaypoints)
            {
                Gizmos.DrawWireSphere((Vector3)waypoints, 0.2f);
            }
        }
        else
        {
            foreach (var waypoints in localWaypoints)
            {
                Gizmos.DrawWireSphere(transform.position + (Vector3)waypoints, 0.2f);
            }
        }
    }

}
