using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAudio : MonoBehaviour
{
    [Header("Finish Audio")]
    [SerializeField] AudioClip finishAudio;
    [SerializeField] [Range(0, 1)] float finishVolume = 0.5f;

    [Header("Crash Audio")]
    [SerializeField] AudioClip crashAudio;
    [SerializeField] [Range(0, 1)] float crashVolume = 0.5f;

    [Header("Thrust Audio")]
    [SerializeField] AudioClip thrustAudio;
    [SerializeField] [Range(0, 1)] float thrustVolume = 0.5f;

    
    AudioSource audioSource;
    
    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = thrustAudio;
        audioSource.volume = thrustVolume;
    }

    public void PlayThrusAudio()
    {
        audioSource.Play();
    }

    public void StopThrustAudio()
    {
        audioSource.Stop();
    }

    public void PlayCrashAudio()
    {
        audioSource.PlayOneShot(crashAudio, crashVolume);
    }

    public void PlayFinishAudio()
    {
        audioSource.PlayOneShot(finishAudio, finishVolume);
    }
}
