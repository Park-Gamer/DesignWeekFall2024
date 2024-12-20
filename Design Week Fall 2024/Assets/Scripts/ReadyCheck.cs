using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyCheck : MonoBehaviour
{
    public bool p1Ready = false;
    public bool p2Ready = false;
    public GameObject ready1Off, ready1On, ready2Off, ready2On;

    MenuAudio audioController;

    public GameObject dialogeExchange;

    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<MenuAudio>(); // Get audio manager
    }

    private void Start()
    {
        ready1On.SetActive(false);
        ready2On.SetActive(false);
        dialogeExchange.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !p1Ready)
        {
            p1Ready = true;
            ready1Off.SetActive(false);
            ready1On.SetActive(true);
            audioController.PlaySFX(audioController.readyClick);
        }
        if (Input.GetKeyDown(KeyCode.D) && !p2Ready)
        {
            p2Ready = true;
            ready2Off.SetActive(false);
            ready2On.SetActive(true);
            audioController.PlaySFX(audioController.readyClick);
        }

        if (p1Ready && p2Ready)
        {
            ready1On.SetActive(false);
            ready2On.SetActive(false);
            dialogeExchange.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R)) // Reload scene
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
