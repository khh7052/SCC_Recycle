using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkInteraction : MonoBehaviour, IInteractable
{
    //public Cainos.CustomizablePixelCharacter.PixelCharacterController Charactor;
    public int id;
    //public bool isNPC;
    
    public GameObject talkPanel;
    public TMP_Text text;
    public bool isAction;
    private TalkManager talkManager;
    int idValue = 0;

    void Start()
    {
        talkPanel.SetActive(false);
        talkManager = TalkManager.Instance; // TalkManager �ν��Ͻ��� �����ɴϴ�.
    }

    public void Interact()
    {

        if (!isAction)
        {
                idValue = 0;
                isAction = true;
                
            talkPanel.SetActive(true);
                
            string talkData = talkManager.Gettalk(id, idValue);
                text.text = talkData;         
        }
        else
        {
                idValue++;
                string talkData = talkManager.Gettalk(id, idValue);
                text.text = talkData;
                if (talkData == null)
                {
                    talkPanel.SetActive(false);
                
                isAction = false;
                
                return;
            }
        }
    }

    void Key()
    {

    }

    public void InteractEnter()
    {
    }

    public void InteractExit()
    {
        talkPanel.SetActive(false);
        ResetInteraction(); // ��ȣ�ۿ� �ʱ�ȭ
    }

    private void ResetInteraction()
    {
        isAction = false;
        idValue = 0;
    }
}

