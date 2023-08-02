using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.CustomizablePixelCharacter;

public interface IInteractable
{
    public void InteractEnter(); // 플레이어와 처음 충돌했을 때
    public void Interact(); // 플레이어가 상호작용키를 눌렀을 때
    public void InteractExit(); // 플레이어가 처음 충돌에서 벗어났을 때
}
