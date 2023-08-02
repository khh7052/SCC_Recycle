using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.CustomizablePixelCharacter;

public class SpikeBall : MonoBehaviour
{
    public Transform destination;
    public Rigidbody2D rbody;

    private void Awake()
    {
        destination = GameObject.Find("MoveTarget").transform; // ���� ������ ����̴ϱ� ���߿� target �����ϴ� ��� �ٲ�ߵ�
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            SystemManager.Instance.StartAutoMove(destination);
            SoundManager.Instance.PlaySFX("Damage", transform.position);
            Destroy(gameObject, 0.1f);
        }
        
    }
}
