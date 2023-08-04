using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void SetMoveBlend(float moveBlend)
    {
        animator.SetFloat("MoveBlend", moveBlend);
    }
    public void SetIsGrounded(bool isGrounded)
    {
        animator.SetBool("IsGrounded", isGrounded);
    }

    public void SetVelocityX(float amount)
    {
        animator.SetFloat("VelocityX", amount);
    }

    public void SetVelocityY(float amount)
    {
        animator.SetFloat("VelocityY", amount);
    }

    public void Idle()
    {
        animator.SetFloat("MoveBlend", 0f);
    }

    public void Walk()
    {
        animator.SetFloat("MoveBlend", 1f);
    }

    public void Run()
    {
        animator.SetFloat("MoveBlend", 3f);
    }

    public void Dash(bool isDashing)
    {
        animator.SetBool("IsDashing", isDashing);
    }

    public void CrouchIdle()
    {
        animator.SetBool("IsCoruching", true);
        animator.SetBool("IsMoving", false);
    }

    public void CrouchMove()
    {
        animator.SetBool("IsCoruching", true);
        animator.SetBool("IsMoving", false);
    }

    public void DodgeFront()
    {
        animator.SetBool("IsDodging", true);
        animator.SetInteger("DodgeDir", 1);
    }

    public void DodgeBack()
    {
        animator.SetBool("IsDodging", true);
        animator.SetInteger("DodgeDir", -1);
    }

    public void AirDown()
    {

    }

    public void Land()
    {
        animator.SetBool("IsGrounded", true);
    }

    public void Crawl(bool isCrawling, Vector2 move, int moveDir)
    {
        animator.SetBool("IsCrawling", isCrawling);
        animator.SetFloat("CrawlSpeedMul", Mathf.Abs(move.x) * moveDir);
    }

    public void Move(bool isMoving, Vector2 move)
    {
        animator.SetBool("IsMoving", isMoving);
        animator.SetFloat("VelocityX", move.x);
        animator.SetFloat("VelocityY", move.y);
    }

}
