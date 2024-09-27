using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    [SerializeField] private Sound[] musicSounds, sfxSounds;
    
    [SerializeField] private AudioSource musicSource, sfxSource;

    private string _lastSong;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayMusic(string musicName)
    {
        Sound sound = Array.Find(musicSounds, x => x.soundName == musicName);
        if (sound == null)
        {
            Debug.LogError("Sound not found");
        }
        else
        {
            if (musicName == _lastSong) return;
            _lastSong = sound.soundName;
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }
    public void PlayEffect(string effectName)
    {
        Sound effect = Array.Find(sfxSounds, x => x.soundName == effectName);
        if (effect == null)
        {
            Debug.LogError("Effect not found");
        }
        else
        {
            sfxSource.PlayOneShot(effect.clip);
        }
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void StopMusic()
    {
        _lastSong = "";
        musicSource.Stop();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    
}
