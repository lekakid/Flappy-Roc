using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] AudioClips;

    public static SoundManager Instance {
        get { return _instance; }
    }

    static SoundManager _instance;
    AudioSource _audioSource;
    Dictionary<string, AudioClip> _clipDicionary;
    
    void Awake()
    {
        _instance = this;
        _audioSource = GetComponent<AudioSource>();
        _clipDicionary = new Dictionary<string, AudioClip>();

        foreach(AudioClip ac in AudioClips) {
            _clipDicionary.Add(ac.name, ac);
        }
    }

    public void Play(string name) {
        _audioSource.PlayOneShot(_clipDicionary[name]);
    }
}
