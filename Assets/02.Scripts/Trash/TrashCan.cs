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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Trash"))
        {
            TrashObject trashObject = collision.gameObject.GetComponent<TrashObject>();

            if (trashObject == null) return;
            Trash trash = trashObject.trash;
            string sound = (trash.Type == type) ? "Correct" : "Incorrect";
            trashObject.StartEquip(sound);

            if (trash.Type == type) count++;

            if (onRecycle) SaveManager.SaveFile.RecycleTrash(collision.gameObject.name);

            OnRecycle.Invoke();
        }
    }

}
