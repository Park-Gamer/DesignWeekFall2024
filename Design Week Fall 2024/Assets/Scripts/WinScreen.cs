using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI player1Win, player2Win;
    public GameObject winScreen;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        winScreen.SetActive(false);
    }
    private void Update()
    {

        player1Win.text = "Winner!";
        player2Win.text = "Winner!";
    }
}
