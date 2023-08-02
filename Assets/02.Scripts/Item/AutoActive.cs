using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoActive : MonoBehaviour
{
    public bool activePlayerDie = true; // 플레이어가 죽을 때 활성화여부

    private void Awake()
    {
        GameManager.OnPlayerDie.AddListener(PlayerDieActive);
    }

    void PlayerDieActive()
    {
        gameObject.SetActive(activePlayerDie);
    }
}
