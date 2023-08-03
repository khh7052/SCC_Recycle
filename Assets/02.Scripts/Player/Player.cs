using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum State
    {
        STAND, // 처음 시작 시 가만히 있음
        RUN, // 플레이할 때 달리기
        HIT // 장애물 충돌할 때 히트
    }

    [Header("Jump")]
    public KeyCode jumpKey;
    public int jumpMaxCount = 2;
    public float startJumpPower = 5f;
    public float jumpPower = 5f;
    public float jumpHeight = 2f;
    private int jumpCurrentCount = 0;
    private bool isJumping = false;
    private bool isGround = false;

    private Rigidbody2D rigd;
    private Animator anim;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        jumpCurrentCount = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        
    }

    void Jump()
    {
        if (jumpCurrentCount > jumpMaxCount) return;
        isJumping = true;
        jumpCurrentCount++;

        float power = jumpCurrentCount == 1 ? startJumpPower : jumpPower;

        rigd.AddForce(power * Vector2.up, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            jumpCurrentCount = 0;
            isGround = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
