using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXButton : MonoBehaviour
{
    public string sfxName;
    private Button button;
    private bool isInit = false;

    private void Start()
    {
        Init(sfxName);
    }

    public void Init(string sfxName)
    {
        if (isInit) return;

        isInit = true;
        this.sfxName = sfxName;
        button = GetComponent<Button>();
        button.onClick.AddListener(() => SoundManager.Instance.PlaySFX(sfxName));
    }

}
