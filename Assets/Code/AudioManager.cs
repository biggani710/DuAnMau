using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioSource vfs;

    public AudioClip musicClip;
    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
