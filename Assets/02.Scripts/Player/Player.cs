using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.PixelHeroes.Scripts.CharacterScrips;
using AnimationState = Assets.PixelHeroes.Scripts.CharacterScrips.AnimationState;

public class Player : MonoBehaviour
{
    public enum State
    {
        STAND, // 처음 시작 시 가만히 있음
        RUN, // 플레이할 때 달리기
        HIT // 장애물 충돌할 때 히트
    }

    [Header("Option")]
    public KeyCode optionKey;
    [Header("Jump")]
    public KeyCode jumpKey;
    public int jumpMaxCount = 2;
    public float startJumpPower = 5f;
    public float jumpPower = 5f;
    private int jumpCurrentCount = 0;
    private bool isGround = false;

    private Rigidbody2D rigd;
    private Character character;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

    void Start()
    {
        jumpCurrentCount = 0;

        AnimUpdate();
        print(character.GetState());
    }

    void Update()
    {
        if (!GameManager.IsLive) return;

        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
        }

        if (Input.GetKeyDown(optionKey))
        {
            UIManager.Instance.ActiveOption(true);
        }

        print(character.GetState());
    }

    void AnimUpdate()
    {
        character.SetState(AnimationState.Running);
    }

    void Jump()
    {
        if (jumpCurrentCount >= jumpMaxCount) return;
        jumpCurrentCount++;

        float power = jumpCurrentCount == 1 ? startJumpPower : jumpPower;
        rigd.velocity = Vector2.zero;
        rigd.AddForce(power * Vector2.up, ForceMode2D.Impulse);
        SoundManager.Instance.PlaySFX("Jump");

        character.SetState(AnimationState.Jumping);
    }

    public void Hit()
    {
        character.Animator.SetTrigger("Hit");
    }

    public void Death()
    {
        character.SetState(AnimationState.Dead);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            jumpCurrentCount = 0;
            isGround = true;

            character.SetState(AnimationState.Running);
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
        if (collision.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            GameManager.Instance.Score += 20;
            SoundManager.Instance.PlaySFX("Coin");
        }
        else if (collision.CompareTag("Damage"))
        {
            GameManager.Instance.HitDamage();
            SoundManager.Instance.PlaySFX("Damage");
        }
        else if (collision.CompareTag("Trash"))
        {
            collision.gameObject.SetActive(false);
            SoundManager.Instance.PlaySFX("Trash");
            TrashManager.Instance.AddTrash(collision.name);
        }
    }
}
