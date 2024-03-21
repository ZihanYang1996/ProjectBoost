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
    // AudioSource oneShotAudioSource;
    
    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        // oneShotAudioSource = gameObject.AddComponent<AudioSource>();
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
        // audioSource.PlayOneShot(crashAudio, crashVolume);  // Not working when thrusters are playing
        AudioSource.PlayClipAtPoint(crashAudio, transform.position, crashVolume);
        // oneShotAudioSource.PlayOneShot(crashAudio, crashVolume);

    }

    public void PlayFinishAudio()
    {
        // audioSource.PlayOneShot(finishAudio, finishVolume);
        AudioSource.PlayClipAtPoint(finishAudio, transform.position, finishVolume);
        // oneShotAudioSource.PlayOneShot(finishAudio, finishVolume);
    }
}
