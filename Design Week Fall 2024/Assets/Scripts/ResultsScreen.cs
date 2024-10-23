using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsScreen : MonoBehaviour
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
        yield return new WaitForSeconds(9f);
        resultsScreen.SetActive(false);
        yield return new WaitForSeconds(2f);
        SceneTransition();
    }

    void SceneTransition()
    {
        if(gameManager.monkey1Win && !gameManager.monkey2Win) 
        {
            SceneManager.LoadScene("Player1Win");
        }
        else if (gameManager.monkey2Win && !gameManager.monkey1Win)
        {
            SceneManager.LoadScene("Player2Win");
        }
    }
}
