using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource bgmSource, sfxSource;
    public Sound[] bgmSounds, sfxSounds;
    private Dictionary<string, Sound> bgmDictionary, sfxDictionary = new();
    public AudioSource sfxSpeaker;
    private Dictionary<GameObject, AudioSource> sfxSpeakers = new();
    public float bgmVolume = 1f;
    public float sfxVolume = 1f;
    private Sound currentBGM, currentSFX;

    public override void Awake()
    {
        base.Awake();
        Init();
    }

    private void OnEnable()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        PlayBGM(sceneName);
    }

    // Dictionary �ʱ�ȭ
    private void Init()
    {
        if(bgmDictionary == null) bgmDictionary = new();
        else bgmDictionary.Clear();

        if(sfxDictionary == null) sfxDictionary = new();
        else sfxDictionary.Clear();

        foreach (Sound bgmSound in bgmSounds)
        {
            bgmDictionary.Add(bgmSound.name, bgmSound);
        }

        foreach (Sound sfxSound in sfxSounds)
        {
            sfxDictionary.Add(sfxSound.name, sfxSound);
        }
    }

    // �Էµ� BGM ����
    public void PlayBGM(string name, bool random = true)
    {
        if (!bgmDictionary.ContainsKey(name)) return;
        if (bgmDictionary[name].clips.Length == 0) return;
        Sound sound = bgmDictionary[name];

        AudioClip[] clips = sound.clips;
        if (clips == null) return;

        int idx = random ? Random.Range(0, clips.Length) : 0;
        bgmSource.clip = clips[idx];

        bgmSource.volume = 0f;
        bgmSource.Play();
        StartCoroutine(FadingBGM(sound.volume));

        currentBGM = sound;
    }

    // �Էµ� SFX ����
    public void PlaySFX(string name, bool random = true)
    {
        if (!sfxDictionary.ContainsKey(name)) return;
        Sound sound = sfxDictionary[name];

        AudioClip[] clips = sound.clips;
        if (clips == null) return;
        
        int idx = random ? Random.Range(0, clips.Length) : 0;
        AudioClip clip = clips[idx];
        
        sfxSource.volume = sound.volume * sfxVolume;
        sfxSource.clip = clip;
        
        if (sfxSource.isPlaying)
        {
            sfxSource.PlayOneShot(clip);
        }
        else
        {
            sfxSource.clip = clip;
            sfxSource.Play();
        }

        currentSFX = sound;
    }

    // ���� BGM ����
    public void StopBGM()
    {
        StartCoroutine(FadingBGM(0f));
    }

    // ���� SFX ����
    public void StopSFX()
    {
        sfxSource.Stop();
    }
    
    // BGM Mute ���
    public void ToggleBGM()
    {
        bgmSource.mute = !bgmSource.mute;
    }

    // SFX Mute ���
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    // BGM ���� ����
    public void BGMVolume(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);
        bgmSource.volume = bgmVolume * currentBGM.volume;
    }

    // SFX ���� ����
    public void SFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        sfxSource.volume = sfxVolume * currentSFX.volume;
    }

    IEnumerator FadingBGM(float targetVolume)
    {
        while (bgmSource.volume != targetVolume * bgmVolume)
        {
            bgmSource.volume = Mathf.MoveTowards(bgmSource.volume, targetVolume * bgmVolume, Time.deltaTime);
            yield return null;
        }
    }
}
