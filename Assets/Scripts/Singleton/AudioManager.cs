using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        LoadVolumes();
    }

    private const string MASTER_VOL_KEY = "AudioMaster";
    private const string MUSIC_VOL_KEY  = "AudioMusic";
    private const string SFX_VOL_KEY    = "AudioSFX";

    private static readonly float defaultVolume = 0.75f;

    private float masterVolume = defaultVolume;
    public float MasterVolume
    {
        get => masterVolume;
        set
        {
            masterVolume = Mathf.Clamp01(value);
            PlayerPrefs.SetFloat(MASTER_VOL_KEY, masterVolume);
            ApplyMusicVolume();
            ApplySFXVolumes();
        }
    }

    private float musicVolume = defaultVolume;
    public float MusicVolume
    {
        get => musicVolume;
        set
        {
            musicVolume = Mathf.Clamp01(value);
            PlayerPrefs.SetFloat(MUSIC_VOL_KEY, musicVolume);
            ApplyMusicVolume();
        }
    }

    private float sfxVolume = defaultVolume;
    public float SFXVolume
    {
        get => sfxVolume;
        set
        {
            sfxVolume = Mathf.Clamp01(value);
            PlayerPrefs.SetFloat(SFX_VOL_KEY, sfxVolume);
            ApplySFXVolumes();
        }
    }

    private List<AudioSource> sfxSources;
    private AudioSource musicSource;
    
    private Dictionary<AudioSource, float> requestedVolumes;

    void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();

        sfxSources = new List<AudioSource>();
        requestedVolumes = new Dictionary<AudioSource, float>();
    }

    public void PlaySound(AudioClip clip, float volume = 1f, float pitch = 1f, bool loop = false)
    {
        AudioSource source = GetAvailableSource();

        source.clip = clip;
        source.pitch = pitch;
        source.loop = loop;

        requestedVolumes[source] = volume;
        source.volume = volume * sfxVolume * masterVolume;

        source.Play();
    }

    public void PlayMusic(AudioClip clip, float volume = 1f)
    {
        if (musicSource.clip == clip && musicSource.isPlaying) return;

        musicSource.clip = clip;
        musicSource.loop = true;

        requestedVolumes[musicSource] = volume;
        musicSource.volume = volume * musicVolume * masterVolume;

        musicSource.Play();
    }

    public void StopAllSounds()
    {
        foreach (AudioSource source in sfxSources)
        {
            if (source.isPlaying)
            {
                source.Stop();
            }
        }
    }

    public void StopMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    private void LoadVolumes()
    {
        masterVolume = PlayerPrefs.GetFloat(MASTER_VOL_KEY, defaultVolume);
        musicVolume = PlayerPrefs.GetFloat(MUSIC_VOL_KEY, defaultVolume);
        sfxVolume = PlayerPrefs.GetFloat(SFX_VOL_KEY, defaultVolume);
    }

    public void SaveVolumes()
    {
        PlayerPrefs.Save();
    }

    private AudioSource GetAvailableSource()
    {
        foreach (AudioSource source in sfxSources)
        {
            if (!source.isPlaying)
            {
                return source;
            }
        }

        return CreateSource();
    }

    private AudioSource CreateSource()
    {
        AudioSource createdSource = gameObject.AddComponent<AudioSource>();
        sfxSources.Add(createdSource);
        return createdSource;
    }

    private void ApplyMusicVolume()
    {
        if (musicSource == null) return;

        float raw = requestedVolumes.ContainsKey(musicSource)
            ? requestedVolumes[musicSource]
            : 1f;

        musicSource.volume = raw * musicVolume * masterVolume;
    }

    private void ApplySFXVolumes()
    {
        if (sfxSources == null) return;

        foreach (AudioSource source in sfxSources)
        {
            float raw = requestedVolumes.ContainsKey(source)
                ? requestedVolumes[source]
                : 1f;

            source.volume = raw * sfxVolume * masterVolume;
        }
    }
}