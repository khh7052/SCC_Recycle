using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.CustomizablePixelCharacter;

public interface IInteractable
{
    public void InteractEnter(); // �÷��̾�� ó�� �浹���� ��
    public void Interact(); // �÷��̾ ��ȣ�ۿ�Ű�� ������ ��
    public void InteractExit(); // �÷��̾ ó�� �浹���� ����� ��
}
