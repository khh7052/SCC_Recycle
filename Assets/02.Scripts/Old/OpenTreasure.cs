using Cainos.PixelArtPlatformer_Dungeon;
using Cainos.PixelArtPlatformer_VillageProps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTreasure : MonoBehaviour, IInteractable
{
    [SerializeField] Cainos.PixelArtPlatformer_VillageProps.Chest IsChest;
    [SerializeField] Door IsDoor;
    

    
    void Start()
    {
        
    }

    public void Interact()
    {
        
            IsChest.Open();
            Invoke("Close", 3f);
        
    }

    public void Close()
    {
        IsChest.Close();
    }

    public void InteractEnter()
    {
    }

    public void InteractExit()
    {
    }
}
