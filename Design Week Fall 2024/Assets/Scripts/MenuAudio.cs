using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [Header("----------- Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------- Audio Clips -----------")]
    public AudioClip menuMusic;
    public AudioClip bananaButton;
    public AudioClip readyClick;

    private void Start()
    {
        musicSource.clip = menuMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void ButtonPress()
    {
        SFXSource.PlayOneShot(bananaButton);
    } 
}
