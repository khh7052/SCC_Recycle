using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.CustomizablePixelCharacter;

public class GhostPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LayerMask collisionMask;
    public Color ghostColor;

    private Animator animator;
    private Collider2D coll;
    private CharacterColorController characterColorController;
    float myZ = -1f;

    public void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        coll = GetComponent<Collider2D>();
        characterColorController = GetComponent<CharacterColorController>();
        animator.SetBool("IsMoving", true);
        animator.SetFloat("MoveBlend", 1.0f);
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input.x != 0)
        {
            Vector3 scale = animator.transform.localScale;
            scale.z = input.x;
            animator.transform.localScale = scale;
        }

        Vector2 velocity = input.normalized * moveSpeed;
        Vector2 animVelocity = velocity;
        if (animVelocity.y == 0) animVelocity.y = 3;

        animator.SetFloat("VelocityX", Mathf.Abs(animVelocity.x));
        animator.SetFloat("VelocityY", animVelocity.y);

        transform.Translate(velocity * Time.deltaTime);
    }

    void OnEnable()
    {
        Vector3 pos = PixelCharacter.instance.transform.position;
        pos.z = myZ;
        transform.position = pos;
        CameraFollow.Instance.target = transform;
        characterColorController.SetCharacterColor(ghostColor);
    }

    private void OnDisable()
    {
        if (GameManager.ApplicationIsQuitting) return;

        CameraFollow.Instance.target = PixelCharacter.instance.transform;

        if (GameManager.Instance.isPlayerDying) return;

        Collider2D hit = Physics2D.OverlapBox(transform.position, coll.bounds.size, 0, collisionMask);
        if (hit == null)
        {
            PixelCharacter.instance.transform.position = transform.position;
        }

        
    }
}
