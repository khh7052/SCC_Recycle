using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.CustomizablePixelCharacter;

public class SystemManager : Singleton<SystemManager>
{
    public float autoMoveSpeed = 20f;

    private bool isAutoMoving = false;

    private Animator animator;
    private PixelCharacterController controller;
    private PixelCharacterInputMouseAndKeyboard input;
    

    public void StartAutoMove(Transform destination)
    {
        StartCoroutine(AutoMove(destination));
    }

    IEnumerator AutoMove(Transform destination)
    {
        if (isAutoMoving) yield break;
        isAutoMoving = true;

        animator = PixelCharacter.instance.animator;
        controller = PixelCharacter.instance.controller;
        input = PixelCharacter.instance.input;

        controller.SetVelocity(Vector2.zero);
        controller.enabled = false;
        input.enabled = false;

        animator.SetBool("IsCrawling", false);
        animator.SetBool("IsCrouching", false);
        animator.SetBool("IsGrounded", false);
        animator.SetFloat("VelocityY", 3);

        while (Vector2.Distance(controller.transform.position, destination.position) > 1f)
        {
            controller.transform.position = Vector2.MoveTowards(controller.transform.position, destination.transform.position, autoMoveSpeed * Time.deltaTime);

            yield return null;
        }

        controller.enabled = true;
        input.enabled = true;
        input.InputKeyReset();

        isAutoMoving = false;
    }
}
