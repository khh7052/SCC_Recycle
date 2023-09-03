using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashCan : MonoBehaviour
{
    public TrashType type;
    public TMP_Text typeText;

    private void Awake()
    {
        typeText.text = type.ToString();
    }
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
                SoundManager.Instance.PlaySFX("Correct");
            }
            else
            {
                SoundManager.Instance.PlaySFX("Incorrect");
            }

            collision.gameObject.SetActive(false);
            SaveManager.SaveFile.RecycleTrash(collision.name);

            int trashNum = SaveManager.SaveFile.GetTrashNum();
            UIManager.Instance.CurrentTrashNumTextUpdate();

            if(trashNum == 0)
            {
                UIManager.Instance.ActiveSperateGameEnd(true);
            }
        }
    }
}
