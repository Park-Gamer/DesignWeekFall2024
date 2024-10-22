using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject resultsScreen;
    GameManager gameManager;
    private bool revealState = false;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        resultsScreen.SetActive(false);
    }

    void Update()
    {
        if (gameManager.monkey1Hit || gameManager.monkey2Hit)
        {
            if (!revealState)
            {
                resultsScreen.SetActive(true);
            }
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut() 
    {
        revealState = true;
        yield return new WaitForSeconds(5f);
        resultsScreen.SetActive(false);
    }
}
