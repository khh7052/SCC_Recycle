using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.CustomizablePixelCharacter;

public class AIController : MonoBehaviour
{
    public enum AIControllerState
    {
        NONE,
        PATROL, // ����
        CHASE, // �߰�
        ATTACK // ����
    }

    private SpriteRenderer spriteRenderer;

    [Header("Common")]
    [Range(0f, 360f)]
    public float angle = 90f; // �߰߰���
    public float updateRate = 0.2f;
    public LayerMask targetMask;
    public AIControllerState state = AIControllerState.NONE;
    private Transform target;
    protected Vector2 destination;

    [Header("Move")]
    public float moveSpeed = 5f;
    private float speed = 0f;

    [Header("Patrol")]
    public float minPatrolDistance = 1f; // �ּ� �����Ÿ�
    public float maxPatrolDistance = 5f; // �ִ� �����Ÿ�
    public float minStopTime = 1f; // �ּ� �����ð�
    public float maxStopTime = 5f; // �ִ� �����ð�
    private Vector2 patrolPos;
    private float nextPatrolTime = 0f;

    [Header("Chase")]
    public float chaseDistance = 5f; // �߰� �Ÿ�

    [Header("Attack")]
    public float attackDelay = 1f; // ���� �ӵ�
    public float attackDistance = 1f; // ���� �Ÿ�
    private float nextAttackTime = 0f;
    

    public virtual Vector2 SpriteDir
    {
        get { return spriteRenderer.flipX ? -transform.right : transform.right; }
    }

    private void Awake()
    {
        AwakeInit();
    }

    private void OnEnable()
    {
        StartCoroutine(StateUpdate());
    }

    public virtual void AwakeInit()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    IEnumerator StateUpdate()
    {
        WaitForSeconds wait = new(updateRate);
        speed = moveSpeed * updateRate;

        while (true)
        {
            if (PixelCharacter.instance == null) yield return wait;
            yield return wait;
            
            Vector2 myPos = transform.position;

            RaycastHit2D hit = new();

            if (NearTargetCheck(out hit))
            {
                float distance = hit.distance;

                // �÷��̾ ���ݰŸ� �ȿ� ���� ��
                if (distance <= attackDistance)
                    StateChange(AIControllerState.ATTACK);

                // �÷��̾ �߰ݰŸ� �ȿ� ���� ��
                else if (distance <= chaseDistance)
                    StateChange(AIControllerState.CHASE);

                // �÷��̾ �߰ݰŸ� �ۿ� ���� ��
                else
                    StateChange(AIControllerState.PATROL);
            }
            else
            {
                StateChange(AIControllerState.PATROL);
            }


            switch (state)
            {
                case AIControllerState.NONE:
                    break;
                case AIControllerState.PATROL:
                    PatrolPosUpdate(myPos);
                    destination = patrolPos;
                    Move();
                    break;
                case AIControllerState.CHASE:
                    Move();
                    break;
                case AIControllerState.ATTACK:
                    Attack();
                    break;
                default:
                    break;
            }
        }
    }

    public virtual void StateChange(AIControllerState state)
    {
        if(this.state == state) return;

        this.state = state;
    }

    // �ֺ��� �ִ� Ÿ�� Ȯ��
    public virtual bool NearTargetCheck(out RaycastHit2D hit)
    {
        Vector2 myPos = transform.position;

        hit = Physics2D.CircleCast(myPos, chaseDistance, Vector2.zero, 0f, targetMask);

        if (hit)
        {
            hit = Physics2D.Linecast(myPos, hit.point, targetMask);
            float halfAngle = angle * 0.5f;
            Vector2 direction = (hit.point - myPos).normalized;

            Debug.DrawLine(myPos, hit.point);
            if (Vector2.Angle(SpriteDir, direction) <= halfAngle)
            {
                target = hit.transform;
                destination = hit.point;
                return true;
            }
        }

        return false;
    }

    public virtual void PatrolPosUpdate(Vector2 myPos)
    {
        if (nextPatrolTime > Time.time) return;
        float rand = Random.Range(minPatrolDistance, maxPatrolDistance);
        patrolPos = myPos + Random.insideUnitCircle * rand;

        rand = Random.Range(minStopTime, maxStopTime);
        nextPatrolTime = Time.time + rand;
    }

    public virtual void Move(Vector2 targetPos)
    {
        FacingUpdate(targetPos);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed);
    }

    public virtual void Move()
    {
        FacingUpdate(destination);
        transform.position = Vector2.MoveTowards(transform.position, destination, speed);
    }
    public virtual void Attack()
    {
        if (nextAttackTime > Time.time) return;
        print("Attack");

        nextAttackTime = Time.time + attackDelay;
    }

    public virtual void FacingUpdate(Vector2 targetPos)
    {
        if (transform.position.x == targetPos.x) return;

        // Ÿ���� ���ʿ� ������ ������
        spriteRenderer.flipX = transform.position.x > targetPos.x;
        /*
        int flipX = transform.position.x > targetPos.x ? -1 : 1;
        Vector3 scale = transform.localScale;
        scale.x = flipX;
        transform.localScale = scale;
        */
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);

        Gizmos.color = Color.green;

        if (Application.isPlaying)
        {
            Gizmos.DrawRay(transform.position, new Vector3(Mathf.Cos(angle * 0.5f * Mathf.Deg2Rad) * SpriteDir.x, Mathf.Sin(angle * 0.5f * Mathf.Deg2Rad), 0) * chaseDistance);
            Gizmos.DrawRay(transform.position, new Vector3(Mathf.Cos(-angle * 0.5f * Mathf.Deg2Rad) * SpriteDir.x, Mathf.Sin(-angle * 0.5f * Mathf.Deg2Rad), 0) * chaseDistance);
        }
        else
        {

            Gizmos.DrawRay(transform.position, new Vector3(Mathf.Cos(angle * 0.5f * Mathf.Deg2Rad), Mathf.Sin(angle * 0.5f * Mathf.Deg2Rad), 0) * chaseDistance);
            Gizmos.DrawRay(transform.position, new Vector3(Mathf.Cos(-angle * 0.5f * Mathf.Deg2Rad), Mathf.Sin(-angle * 0.5f * Mathf.Deg2Rad), 0) * chaseDistance);

        }
    }
}
