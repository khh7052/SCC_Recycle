using Cainos.PixelArtPlatformer_Dungeon;
using Cainos.PixelArtPlatformer_VillageProps;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IInteractable
{
    [SerializeField] Switch IsSwitch;
    [SerializeField] BoxCollider2D DoorCollider;
    [SerializeField] GameObject scriptGameObject; // 추가된 게임 오브젝트

    private MonoBehaviour scriptToEnable; // 비활성화된 스크립트 참조 변수

    private bool isDoorOpen = false;

    void Start()
    {
    }

    public void Interact()
    {
       
           
            if(isDoorOpen == true)
            {
                CloseDoor();
            }
            else { DoorOpen(); }
                
            
        

    }

    private void DoorOpen()
    {
        DoorCollider.enabled = false; // BoxCollider2D 비활성화
        IsSwitch.TurnOn();
        isDoorOpen = true;
    }

    private void CloseDoor()
    {
        DoorCollider.enabled = true; // BoxCollider2D 다시 활성화
        IsSwitch.TurnOff();
        isDoorOpen = false;
    }

    private void EnableScript()
    {
        scriptToEnable.enabled = true; // 스크립트 활성화
    }

    private void DisableScript()
    {
        scriptToEnable.enabled = false; // 스크립트 비활성화
    }

    public void InteractEnter()
    {
    }

    public void InteractExit()
    {
    }
}
