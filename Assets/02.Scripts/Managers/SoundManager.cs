using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource bgmSource;
    public AudioSource[] sfxSource;
    public Sound[] bgmSounds, sfxSounds;
    private Dictionary<string, Sound> bgmDictionary, sfxDictionary = new();
    public static float BGM_Volume = 1f;
    public static float SFX_Volume = 1f;
    private Sound currentBGM;

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
        

        foreach (var source in sfxSource)
        {
            if (source.isPlaying) continue;

            source.clip = clip;
            source.volume = sound.volume * SFX_Volume;
            source.Play();
            break;
        }
    }

    // ���� BGM ����
    public void StopBGM()
    {
        bgmSource.Stop();
        //StartCoroutine(FadingBGM(0f));
    }

    // ���� SFX ����
    public void StopSFX()
    {
        foreach (var source in sfxSource)
        {
            source.Stop();
        }
    }
    
    // BGM Mute ���
    public void ToggleBGM()
    {
        bgmSource.mute = !bgmSource.mute;
    }

    // SFX Mute ���
    public void ToggleSFX()
    {
        foreach (var source in sfxSource)
        {
            source.mute = !source.mute;
        }
    }

    // BGM ���� ����
    public void BGMVolume(float volume)
    {
        BGM_Volume = Mathf.Clamp01(volume);

        if (currentBGM != null)
            bgmSource.volume = BGM_Volume * currentBGM.volume;
    }

    // SFX ���� ����
    public void SFXVolume(float volume)
    {
        SFX_Volume = Mathf.Clamp01(volume);

        foreach (var source in sfxSource)
        {
            if(!source.isPlaying) continue;

            source.volume = SFX_Volume * sfxDictionary[source.clip.name].volume;
        }
    }

    IEnumerator FadingBGM(float targetVolume)
    {
        while (bgmSource.volume != targetVolume * BGM_Volume)
        {
            bgmSource.volume = Mathf.MoveTowards(bgmSource.volume, targetVolume * BGM_Volume, Time.deltaTime);
            yield return null;
        }
    }
}
