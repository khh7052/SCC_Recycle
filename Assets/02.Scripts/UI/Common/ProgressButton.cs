using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressButton : MonoBehaviour
{
    public Button button;
    private TutorialUI tutorialUI;
    private int index;

    public void Init(TutorialUI tutorialUI, int index)
    {
        this.tutorialUI = tutorialUI;
        this.index = index;
    }

    public void TutorialUpdate()
    {
        tutorialUI.Index = index;
    }

}
