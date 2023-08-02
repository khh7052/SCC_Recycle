using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoActive : MonoBehaviour
{
    public bool activePlayerDie = true; // �÷��̾ ���� �� Ȱ��ȭ����

    private void Awake()
    {
        GameManager.OnPlayerDie.AddListener(PlayerDieActive);
    }

    void PlayerDieActive()
    {
        gameObject.SetActive(activePlayerDie);
    }
}
