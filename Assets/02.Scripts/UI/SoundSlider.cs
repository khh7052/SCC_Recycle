using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SoundType
{
    BGM,
    SFX,
}

public class SoundSlider : MonoBehaviour
{
    public SoundType type;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        if (!SoundManager.Instance) return;

        slider.value = type == SoundType.BGM ? SoundManager.Instance.bgmVolume : SoundManager.Instance.sfxVolume;
    }
}
