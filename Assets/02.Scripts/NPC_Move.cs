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
    private float directionChangeDelay = 1f; // 방향 전환 시간 (1초)

    void Start()
    {
        StartCoroutine(ToggleIsMoving());
    }

    IEnumerator ToggleIsMoving()
    {
        while (true)
        {
            // 3초 대기
            yield return new WaitForSeconds(3f);

            // isMoving 값을 토글
            isMoving = !isMoving;

            // 방향 전환 시간동안 멈추기
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
            // 멈추는 동안 아무 작업하지 않음
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
            // 플레이어의 위치와 NPC의 위치를 기준으로 방향 벡터를 구합니다.
            Vector2 playerDirection = Player.transform.position - transform.position;
            Vector2 npcDirection = CharactorCon.inputMove.normalized;

            // 두 벡터가 반대 방향인 경우 뒤에서 충돌한 것으로 판단
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
