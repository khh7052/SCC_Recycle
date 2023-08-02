using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.CustomizablePixelCharacter;

public class Gliding : Item
{
    public float gravityAmount = 0.1f;

    public override void InteractEnter()
    {
        PixelCharacter.instance.controller.SetGliding(true, gravityAmount);
        gameObject.SetActive(false);
        // SoundManager.Instance.PlaySFX("");

        Invoke("Reactivate", 5f);
    }

    private void Reactivate()
    {
        gameObject.SetActive(true);
    }
}
