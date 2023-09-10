using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TrashCan : MonoBehaviour
{
    public UnityEvent OnRecycle;
    public TrashType type;
    public TMP_Text typeText;
    public bool onRecycle;
    private int count = 0;

    public int TrashCount
    {
        get { return count; }
    }

    private void Awake()
    {
        if (typeText == null) return;
        typeText.text = type.ToString();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trash"))
        {
            Trash trash = TrashManager.Instance.GetTrashInform(collision.gameObject.name);

            if (trash == null) return;

            if (trash.Type == type)
            {
                count++;
                SoundManager.Instance.PlaySFX("Correct");
            }
            else
            {
                SoundManager.Instance.PlaySFX("Incorrect");
            }

            if (onRecycle) SaveManager.SaveFile.RecycleTrash(collision.gameObject.name);
            collision.gameObject.SetActive(false);

            OnRecycle.Invoke();
        }
    }


}
