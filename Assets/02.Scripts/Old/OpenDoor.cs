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
    [SerializeField] GameObject scriptGameObject; // �߰��� ���� ������Ʈ

    private MonoBehaviour scriptToEnable; // ��Ȱ��ȭ�� ��ũ��Ʈ ���� ����

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
        DoorCollider.enabled = false; // BoxCollider2D ��Ȱ��ȭ
        IsSwitch.TurnOn();
        isDoorOpen = true;
    }

    private void CloseDoor()
    {
        DoorCollider.enabled = true; // BoxCollider2D �ٽ� Ȱ��ȭ
        IsSwitch.TurnOff();
        isDoorOpen = false;
    }

    private void EnableScript()
    {
        scriptToEnable.enabled = true; // ��ũ��Ʈ Ȱ��ȭ
    }

    private void DisableScript()
    {
        scriptToEnable.enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
    }

    public void InteractEnter()
    {
    }

    public void InteractExit()
    {
    }
}
