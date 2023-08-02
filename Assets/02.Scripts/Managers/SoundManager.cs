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

    // Dictionary 초기화
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

    // 입력된 BGM 실행
    public void PlayBGM(string name, bool random = true)
    {
        if (!bgmDictionary.ContainsKey(name)) return;
        Sound sound = bgmDictionary[name];

        AudioClip[] clips = sound.clips;
        if (clips == null) return;

        int idx = random ? Random.Range(0, clips.Length) : 0;
        bgmSource.clip = clips[idx];

        /*
        bgmSource.volume = sound.volume;
        */
        bgmSource.volume = 0f;
        bgmSource.Play();
        StartCoroutine(FadingBGM(sound.volume));
    }

    // 입력된 SFX 실행
    public void PlaySFX(string name, Vector2 pos, bool random = true)
    {
        if (!sfxDictionary.ContainsKey(name)) return;
        Sound sound = sfxDictionary[name];

        AudioClip[] clips = sound.clips;
        if (clips == null) return;
        
        int idx = random ? Random.Range(0, clips.Length) : 0;
        AudioClip clip = clips[idx];
        
        sfxSource.volume = sound.volume;
        sfxSource.clip = clip;


        GameObject speakerObject = PoolManager.Instance.Pop(sfxSpeaker.gameObject, pos, Quaternion.identity);
        if (!sfxSpeakers.ContainsKey(speakerObject))
        {
            sfxSpeakers.Add(speakerObject, speakerObject.GetComponent<AudioSource>());
        }
        //AudioSource audioSource = PoolManager.Instance.Pop(sfxSpeaker.gameObject, pos, Quaternion.identity).GetComponent<AudioSource>();
        AudioSource speaker = sfxSpeakers[speakerObject];
        speaker.volume = sound.volume;
        speaker.clip = clip;
        speaker.Play();

        /*
        if (sfxSource.isPlaying)
        {
            sfxSource.PlayOneShot(clip);
        }
        else
        {
            sfxSource.clip = clip;
            sfxSource.Play();
        }
        */

    }

    // 현재 BGM 중지
    public void StopBGM()
    {
        StartCoroutine(FadingBGM(0f));
    }

    // 현재 SFX 중지
    public void StopSFX()
    {
        sfxSource.Stop();
    }
    
    // BGM Mute 토글
    public void ToggleBGM()
    {
        bgmSource.mute = !bgmSource.mute;
    }

    // SFX Mute 토글
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    // BGM 볼륨 조절
    public void BGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    // SFX 볼륨 조절
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    IEnumerator FadingBGM(float targetVolume)
    {
        while (bgmSource.volume != targetVolume)
        {
            bgmSource.volume = Mathf.MoveTowards(bgmSource.volume, targetVolume, Time.deltaTime);
            yield return null;
        }

        if (bgmSource.volume == 0f)
            bgmSource.Stop();

    }
}
