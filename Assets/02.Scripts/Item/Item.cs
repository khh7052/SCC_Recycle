using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.CustomizablePixelCharacter;

public class Item : MonoBehaviour, IInteractable
{
    public string itemName = "None";
    [HideInInspector]
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void Interact()
    {
    }

    public virtual void InteractEnter()
    {
        if (gameObject.activeInHierarchy == false) return;
        print($"{itemName} Å‰µæ!");

        PixelCharacter.instance.inventory.AddItem(this);
        gameObject.SetActive(false);
    }

    public virtual void InteractExit()
    {
        if (gameObject.activeInHierarchy == false) return;
    }
}
