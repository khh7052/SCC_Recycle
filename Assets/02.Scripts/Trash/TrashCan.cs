using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public TrashType type;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trash"))
        {
            Trash trash = TrashManager.Instance.GetTrashInform(collision.name);

            if(trash == null)
            {
                print("없음");
                return;
            }

            if(trash.type == type)
            {
                print("정답");
            }

            collision.gameObject.SetActive(false);
            TrashManager.Instance.RecycleTrash(collision.name);
        }
    }
}
