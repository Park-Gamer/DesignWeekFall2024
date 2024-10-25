using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogeExchange : MonoBehaviour
{
    [Header("----------- Game Objects -----------")]
    [SerializeField] GameObject Monkey1;
    [SerializeField] GameObject Monkey2;

    [Header("----------- Audio Source -----------")]
    [SerializeField] AudioSource monkey1Dialoge;
    [SerializeField] AudioSource monkey2Dialoge;

    [Header("----------- Audio Clips -----------")]
    public AudioClip[] monkey1VLines;
    public AudioClip[] monkey2VLines;

    private Animator m1Anim;
    private Animator m2Anim;

    void Start()
    {
        // Get player components
        m1Anim = Monkey1.GetComponent<Animator>();
        m2Anim = Monkey2.GetComponent<Animator>();

        // Check if the audio clips array is not empty
        if (monkey1VLines.Length > 0)
        {
            m1Anim.SetBool("m1isTalking", true); // Play animation
            Monkey1PlayRandomClip();
            StartCoroutine(Monkey1DialogeLength());
        }
        else
        {
            Debug.LogWarning("No audio clips assigned to the array.");
        }
    }

    void Monkey1PlayRandomClip()
    {
        // Select a random clip from the array
        int m1randomIndex = Random.Range(0, monkey1VLines.Length);
        AudioClip m1randomClip = monkey1VLines[m1randomIndex];

        // Play the selected audio clip
        monkey1Dialoge.clip = m1randomClip;
        monkey1Dialoge.Play();

        // Optional: Log the name of the clip being played
        Debug.Log("Playing clip: " + m1randomClip.name);
    }
    void Monkey2PlayRandomClip()
    {
        // Select a random clip from the array
        int m2randomIndex = Random.Range(0, monkey2VLines.Length);
        AudioClip m2randomClip = monkey2VLines[m2randomIndex];

        // Play the selected audio clip
        monkey2Dialoge.clip = m2randomClip;
        monkey2Dialoge.Play();

        // Optional: Log the name of the clip being played
        Debug.Log("Playing clip: " + m2randomClip.name);
    }

    IEnumerator Monkey1DialogeLength() // Countdown till draw timer
    {
        yield return new WaitForSeconds(4f); // Wait before activating text
        m1Anim.SetBool("m1isTalking", false);
        Monkey2StartDialoge();
    }

    IEnumerator Monkey2DialogeLength() // Countdown till draw timer
    {
        yield return new WaitForSeconds(4.3f); // Wait before activating text
        m2Anim.SetBool("m2isTalking", false);
        SceneManager.LoadScene("MainGame");
    }

    void Monkey2StartDialoge()
    {
        if (monkey2VLines.Length > 0)
        {
            m2Anim.SetBool("m2isTalking", true); // Play animation
            Monkey2PlayRandomClip();
            StartCoroutine(Monkey2DialogeLength());
        }
        else
        {
            Debug.LogWarning("No audio clips assigned to the array.");
        }
    }
}
