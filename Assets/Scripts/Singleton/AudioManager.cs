using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private List<AudioSource> audioSources;

    private AudioSource GetAvailableSource()
    {
        return null;
    }

    private AudioSource CreateSource()
    {
        AudioSource createdSource = gameObject.AddComponent<AudioSource>();

        audioSources.Add(createdSource);

        return createdSource;
    }

    public void PlaySound()
    {
        AudioSource currentSource = GetAvailableSource();
        
        if (currentSource == null)
        {
            currentSource = CreateSource();
        }
    }
}