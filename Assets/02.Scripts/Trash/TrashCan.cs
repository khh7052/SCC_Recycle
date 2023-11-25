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

    private void CheckTrash(TrashObject trashObject)
    {
        if (trashObject == null) return;
        Trash trash = trashObject.trash;
        bool recycleOn = false;
        
        if (trash.trashTypeInformation.originalType == type || trash.trashTypeInformation.integrateType == type)
            recycleOn = true;
        
        string sound = recycleOn ? "Correct" : "Incorrect";
        SoundManager.Instance.PlaySFX(sound);
        trashObject.StartEquip();

        // 타입 올바르면 재활용
        if (recycleOn)
        {
            EmissionManager.Instance.CorrectTrash(trash);
            SaveManager.SaveFile.RecycleTrash(trashObject.trash.trashSaveName);
            count++;
        }
        // 타입 다르면 제거
        else
        {
            EmissionManager.Instance.IncorrectTrash(trash);
            SaveManager.SaveFile.RemoveTrash(trashObject.trash.trashSaveName);
        }

        
        OnRecycle.Invoke();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Trash"))
        {
            TrashObject trashObject = collision.gameObject.GetComponent<TrashObject>();
            CheckTrash(trashObject);
        }
    }

}
