using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.CustomizablePixelCharacter;

public class NPC_Move : MonoBehaviour, IInteractable
{
    public PixelCharacter Player;
    public PixelCharacterController PlayerCon;
    public PixelCharacterController CharactorCon;
    public PixelCharacter Charactor;
    private bool isMoving = false;
    private bool isStop = false;
    private float directionChangeDelay = 1f; // ���� ��ȯ �ð� (1��)

    void Start()
    {
        StartCoroutine(ToggleIsMoving());
    }

    IEnumerator ToggleIsMoving()
    {
        while (true)
        {
            // 3�� ���
            yield return new WaitForSeconds(3f);

            // isMoving ���� ���
            isMoving = !isMoving;

            // ���� ��ȯ �ð����� ���߱�
            isStop = true;
            yield return new WaitForSeconds(directionChangeDelay);
            isStop = false;
        }
    }



    // Update is called once per frame
    private void Update()
    {
        if (isStop)
        {
            // ���ߴ� ���� �ƹ� �۾����� ����
        }
        else if (isMoving)
        {
            CharactorCon.inputMove.x++;
        }
        else if(!isMoving)
        {
            CharactorCon.inputMove.x--;
        }
    }

    public void Interact() { }

    public void InteractEnter()
    {
        if(PlayerCon.IsRunning)
        {
            // �÷��̾��� ��ġ�� NPC�� ��ġ�� �������� ���� ���͸� ���մϴ�.
            Vector2 playerDirection = Player.transform.position - transform.position;
            Vector2 npcDirection = CharactorCon.inputMove.normalized;

            // �� ���Ͱ� �ݴ� ������ ��� �ڿ��� �浹�� ������ �Ǵ�
            if (Vector2.Dot(playerDirection, npcDirection) < 0f)
            {
                Charactor.InjuredBack();
            }
            else
            {
                Charactor.InjuredFront();
            }
        }
    }

    public void InteractExit() { }
}
