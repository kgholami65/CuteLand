using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private AudioClip questCompleteClip;
    [SerializeField] private AudioClip playerHitSound;
    [SerializeField] [Range(0, 1)] private float impactSoundVolume;
    private AudioSource _audioSource;

    private void Awake()
    {
        var instanceCount = FindObjectsOfType<AudioPlayer>().Length;
        if (instanceCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            _audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayCollectSound()
    {
        _audioSource.PlayOneShot(collectSound, impactSoundVolume);
    }
    
    

    public void PlayQuestCompleteSound()
    {
        _audioSource.PlayOneShot(questCompleteClip, impactSoundVolume);
    }
    
    public void PlayPlayerHitSound()
    {
        _audioSource.PlayOneShot(playerHitSound, impactSoundVolume);
    }
    
}
