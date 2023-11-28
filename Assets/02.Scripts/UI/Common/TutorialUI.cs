using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class TutorialData
{
    public Sprite sprite;
    [Multiline()]
    public string description;
    public ProgressButton progressButton;
}

public class TutorialUI : MonoBehaviour
{
    public TutorialData[] tutorialDatas;
    public Image tutorialImage;
    public TMP_Text descriptionText;

    public Button previousButton;
    public Button nextButton;
    public Transform progressButtonParent;
    public ProgressButton progressButton;

    private int index;

    public int Index
    {
        get { return index; }
        set
        {
            tutorialDatas[index].progressButton.button.interactable = true;
            index = Mathf.Clamp(value, 0, tutorialDatas.Length-1);
            tutorialDatas[index].progressButton.button.interactable = false;

            tutorialImage.sprite = tutorialDatas[index].sprite;
            descriptionText.text = tutorialDatas[index].description;

            previousButton.interactable = index > 0;
            nextButton.interactable = index < tutorialDatas.Length-1;
        }
    }

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        Index = 0;
    }

    void Init()
    {
        for (int i = 0; i < tutorialDatas.Length; i++)
        {
            tutorialDatas[i].progressButton = Instantiate(progressButton, progressButtonParent);
            tutorialDatas[i].progressButton.Init(this, i);
        }

        Index = 0;
    }

    public void OnProgressButton(string name)
    {
        Index = int.Parse(name);
    }


    public void OnPrevious()
    {
        Index--;
    }
    public void OnNext()
    {
        Index++;
    }
}
