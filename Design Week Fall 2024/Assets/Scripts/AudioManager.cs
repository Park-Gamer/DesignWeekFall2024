using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    PauseMenu pauseMenu;

    [Header("----------- Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------- Audio Clips -----------")]
    public AudioClip duelMusic;
    public AudioClip num3;
    public AudioClip num2;
    public AudioClip num1;
    public AudioClip draw;
    public AudioClip early;
    public AudioClip bang;

    private void Awake()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PauseMenu>();
    }

    private void Start()
    {
        musicSource.clip = duelMusic;
        musicSource.Play();
    }

    private void Update()
    {
        if (pauseMenu.isPaused)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.UnPause();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
