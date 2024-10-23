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
    public int countdownTime;
    [SerializeField] TextMeshProUGUI countDownVisual;
    [SerializeField] int minTimerValue = 1;
    [SerializeField] int maxTimerValue = 3;
    private int randomInt; // Sets a random number between countdown timer going down to add for unpredictability
    // Draw timers
    public float m1drawTime, m2drawTime;
    private bool m1isTiming = false;
    private bool m2isTiming = false;
    [SerializeField] TextMeshProUGUI monkey1Time, monkey2Time;
    // Bool checks
    [SerializeField] bool canDraw = false; // Determines when players can draw
    public bool monkey1Hit = false; // Determines if player 1 lost
    public bool monkey2Hit = false; // Determines if player 2 lost
    private bool canStart = false;
    private bool hasShot = false;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); // Get audio manager
    }

    void Start()
    {
        // Get player components
        m1Anim = Monkey1.GetComponent<Animator>();
        m2Anim = Monkey2.GetComponent<Animator>();

        StartCoroutine(DrawCountDown()); // Start timer
    }

    void Update()
    {
        WinState();
        // Play audio when either player shoots
        if (Input.GetKeyDown(KeyCode.D) && !hasShot && canDraw) 
        {
            audioManager.PlaySFX(audioManager.bang); 
        }
        else if (Input.GetKeyDown(KeyCode.A) && !hasShot && canDraw)
        {
            audioManager.PlaySFX(audioManager.bang);
        }

        if (canDraw) // Timer check
        {
            m1isTiming = true; // Begins timer for player 1
            m2isTiming = true; // Begins timer for player 2
            Monkey1Check();
            Monkey2Check();
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) // Early user input check
        {
            // Reset variables
            countDownVisual.text = "Too Early!";
            countdownTime = 4;
        }
        else if (Input.GetKeyDown(KeyCode.R)) // Reload scene
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }

    void Monkey1Check() // Player 2 input
    {
        if (Input.GetKeyDown(KeyCode.D) && !monkey1Hit) 
        {
            hasShot = true; 
            m2isTiming = false; // Stops timer when player shot
            m2Anim.SetBool("m2Fire", true); // Play animation
            monkey1Hit = true; // Set player 1 to lose
        }
        if (monkey1Hit && !monkey2Hit) // Checks if player 1 has lost and player 2 hasn't
        {
            m1Anim.SetBool("m1Lose", true);
        }
    }

    void Monkey2Check() // Player 1 input
    {
        if (Input.GetKeyDown(KeyCode.A) && !monkey2Hit)
        {
            hasShot = true; 
            m1isTiming = false; // Stops timer when player shot
            m1Anim.SetBool("m1Fire", true); // Play animation
            monkey2Hit = true; // Set player 2 to lose
        }
        if (monkey2Hit && !monkey1Hit) // Checks if player 2 has lost and player 1 hasn't
        {
            m2Anim.SetBool("m2Lose", true);
        }
    }

    IEnumerator DrawCountDown() // Countdown till draw timer
    {
        while (canStart == false)
        {
            countDownVisual.gameObject.SetActive(false);
            yield return new WaitForSeconds(4f); // Wait before activating text
            canStart = true;
            countDownVisual.gameObject.SetActive(true);
        }
        while (countdownTime > 0 && canStart) // While loop until countdown is zero
        {
            AudioCountDown();
            randomInt = Random.Range(minTimerValue, maxTimerValue + 1); // Gets a random number within the min/max threshold to use for time between counting down
            countDownVisual.text = countdownTime.ToString(); // Convert timer to string for UI
            yield return new WaitForSeconds(randomInt); // Wait the random number before decreasing countdown
            countdownTime--; // Lower countdown
        }
        if (countdownTime == 0)
        {
            audioManager.PlaySFX(audioManager.draw);
        }
        canDraw = true; // When countdown is zero players can draw
        countDownVisual.text = "Draw!"; 
        yield return new WaitForSeconds(1f); // Wait before deleting text
        countDownVisual.gameObject.SetActive(false); // Delete text
    }

    void AudioCountDown()
    {
        // Play audio based on the number in the countdown
        switch (countdownTime)
        {
            case 3:
                audioManager.PlaySFX(audioManager.num3);
                break;
            case 2:
                audioManager.PlaySFX(audioManager.num2);
                break;
            case 1:
                audioManager.PlaySFX(audioManager.num1);
                break;
        }
    }

    void WinState()
    {
        if (m1isTiming) // Starts timer
        {
            m1drawTime += Time.deltaTime; // Time.deltaTime is in seconds
        }
        else // When timer stops
        {
            m1isTiming = false;
            monkey1Time.text = "Monkey 1's Draw Time: " + m1drawTime.ToString("0.000") + "ms"; // Set float variable to text
        }

        if (m2isTiming) // Starts timer
        {
            m2drawTime += Time.deltaTime; // Time.deltaTime is in seconds
        }
        else // When timer stops
        {
            m2isTiming = false;
            monkey2Time.text = "Monkey 2's Draw Time: " + m2drawTime.ToString("0.000") + "ms"; // Set float variable to text
        }
    }
}
