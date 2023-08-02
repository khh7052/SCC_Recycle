using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.CustomizablePixelCharacter;

public class AIController_Character : AIController
{
    private PixelCharacter character;
    private PixelCharacterController myController;

    public override Vector2 SpriteDir
    {
        get { return transform.localScale.z < 0 ? -transform.right : transform.right; }
    }

    public override void AwakeInit()
    {
        base.AwakeInit();
        character = GetComponent<PixelCharacter>();
        myController = GetComponent<PixelCharacterController>();
    }

    public override void StateChange(AIControllerState state)
    {
        base.StateChange(state);
        myController.inputMove.x = 0;
    }

    public override void Move(Vector2 targetPos)
    {
        print("move");
        
        float dir = targetPos.x - transform.position.x;

        if (dir > 0) dir = 1;
        else if (dir < 0) dir = -1;
        else return;

        FacingUpdate(targetPos);
        myController.inputMove.x = dir;
    }

    public override void Move()
    {
        print("move");
        
        float dir = destination.x - transform.position.x;

        if (Mathf.Abs(dir) <= 0.2f)
        {
            Vector2 v = myController.Velocity;
            v.x = 0f;
            myController.Velocity = v;
            return;
        }
        
        if (dir > 0) dir = 1;
        else if (dir < 0) dir = -1;
        else
        {
            Vector2 v = myController.Velocity;
            v.x = 0f;
            myController.Velocity = v;
            return;
        }

        FacingUpdate(destination);
        myController.inputMove.x = dir;
    }

    public override void FacingUpdate(Vector2 targetPos)
    {
        float dir = targetPos.x - transform.position.x;

        if (dir > 0) dir = 1;
        else if (dir < 0) dir = -1;
        else return;


        character.Facing = (int)dir;
    }
}
