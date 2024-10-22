using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables
    // Game Objects
    [SerializeField] GameObject Monkey1;
    [SerializeField] GameObject Monkey2;
    private Animator m1Anim;
    private Animator m2Anim;
    // Countdown timer
    [SerializeField] int countdownTime;
    [SerializeField] TextMeshProUGUI countDownVisual;
    [SerializeField] int minTimerValue = 1;
    [SerializeField] int maxTimerValue = 3;
    private int randomInt; // Sets a random number between countdown timer going down to add for unpredictability
    // Bool checks
    [SerializeField] bool canDraw = false; // Determines when players can draw
    [SerializeField] bool monkey1Hit = false; // Determines if player 1 lost
    [SerializeField] bool monkey2Hit = false; // Determines if player 2 lost

    [SerializeField] bool m1readyCheck = false; // Determines if player 1 is ready
    [SerializeField] bool m2readyCheck = false; // Determines if player 2 is ready

    void Start()
    {
        // Get player components
        m1Anim = Monkey1.GetComponent<Animator>();
        m2Anim = Monkey2.GetComponent<Animator>();

        StartCoroutine(DrawCountDown()); // Start timer
    }

    void Update()
    {
        if (canDraw) // Timer check
        {
            Monkey1Check();
            Monkey2Check();
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) // Early user input check
        {
            // Reset variables
            countDownVisual.text = "Too Early!";
            countdownTime = 4;
        }
        if (Input.GetKeyDown(KeyCode.R)) // Reload scene
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }

    void Monkey1Check() // Player 2 input
    {
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            m2Anim.SetBool("m2Fire", true); // Play animation
            monkey1Hit = true; // Set player 1 to lose
        }
        if (monkey1Hit && !monkey2Hit) // Checks if player 1 has lost and player 2 hasn't
        {
            m1Anim.SetBool("m1Lose", true);
            Debug.Log("Player 2 Wins!");        
        }
    }

    void Monkey2Check() // Player 1 input
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            m1Anim.SetBool("m1Fire", true);
            monkey2Hit = true; // Set player 2 to lose
        }
        if (monkey2Hit && !monkey1Hit) // Checks if player 2 has lost and player 1 hasn't
        {
            m2Anim.SetBool("m2Lose", true);
            Debug.Log("Player 1 Wins!");
        }
    }

    IEnumerator DrawCountDown() // Countdown till draw timer
    {
        while (countdownTime > 0) // While loop until countdown is zero
        {
            randomInt = Random.Range(minTimerValue, maxTimerValue + 1); // Gets a random number within the min/max threshold to use for time between counting down
            countDownVisual.text = countdownTime.ToString(); // Convert timer to string for UI
            yield return new WaitForSeconds(randomInt); // Wait the random number before decreasing countdown
            countdownTime--; // Lower countdown
        }

        canDraw = true; // When countdown is zero players can draw
        countDownVisual.text = "Draw!"; 
        yield return new WaitForSeconds(1f); // Wait before deleting text
        countDownVisual.gameObject.SetActive(false); // Delete text
    }
}
