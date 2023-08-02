using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEffectObject : MonoBehaviour
{
    
    public Color ghostColor;
    private CharacterColorController characterColorController;
    private Animator animator;
    public Animator target;
    float myZ = -0.5f;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        animator.speed = 10f;
        ColorUpdate();
    }

    private void OnEnable()
    {
        Init();
    }

    public void Init()
    {
        animator.SetFloat("VelocityX", target.GetFloat("VelocityX"));
        animator.SetFloat("VelocityY", target.GetFloat("VelocityY"));
        animator.transform.localScale = target.transform.localScale;

        Vector3 pos = transform.position;
        pos.z = myZ;
        transform.position = pos;
    }

    public void ColorUpdate()
    {
        if(characterColorController == null)
            characterColorController = GetComponent<CharacterColorController>();

        characterColorController.SetCharacterColor(ghostColor);
    }
}
