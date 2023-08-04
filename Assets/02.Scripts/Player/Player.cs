using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum State
    {
        STAND, // ó�� ���� �� ������ ����
        RUN, // �÷����� �� �޸���
        HIT // ��ֹ� �浹�� �� ��Ʈ
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
    private CharacterAnimationController animController;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        animController = GetComponent<CharacterAnimationController>();
    }

    void Start()
    {
        jumpCurrentCount = 0;
        animController.Run();
        animController.SetVelocityX(10);
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
        }

        AnimUpdate();
    }

    private void FixedUpdate()
    {
        
    }

    void AnimUpdate()
    {
        Vector2 velocity = rigd.velocity;
        velocity.y = isGround ? 0 : rigd.velocity.y;
        
        animController.SetVelocityY(velocity.y);
        animController.SetIsGrounded(isGround);
    }

    void Jump()
    {
        if (jumpCurrentCount >= jumpMaxCount) return;
        isJumping = true;
        jumpCurrentCount++;

        float power = jumpCurrentCount == 1 ? startJumpPower : jumpPower;
        rigd.velocity = Vector2.zero;
        rigd.AddForce(power * Vector2.up, ForceMode2D.Impulse);
        SoundManager.Instance.PlaySFX("Jump");
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
        if (collision.CompareTag("Item"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
