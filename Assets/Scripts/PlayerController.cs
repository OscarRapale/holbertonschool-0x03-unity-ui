﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 9f; // Public variable to control speed
    public int health = 5; // Public variable for health
    private int initialHealth; // Store initial health for reset
    private int score = 0; // Player score
    private int initialScore; // Store initial score for reset

    public Text scoreText;
    public Text healthText; // Reference to the HealthText UI element
    public Text winLoseText; // Reference to the WinLoseText UI element
    public Image winLoseBG; // Reference to the WinLoseBG UI element

    // Rigidbody component reference
    private Rigidbody rb;

    void Start()
    {
        // Save the initial values for health and score to reset later
        initialHealth = health;
        initialScore = score;

        // Get the Rigidbody component attached to the Player
        rb = GetComponent<Rigidbody>();

        // Initialize the scoreText and HealthText UI
        SetScoreText();
        SetHealthText();

        // Ensure WinLoseBG is inactive at the start
        winLoseBG.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        // Get input from the horizontal (A/D or Left/Right) and vertical (W/S or Up/Down) axes
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector on the X and Z axes
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply force to the Rigidbody to move the Player
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the Player collides with an object tagged "Pickup"
        if (other.gameObject.CompareTag("Pickup"))
        {
            // Increment the score
            score++;

            // Update the ScoreText UI
            SetScoreText();

            // Log the updated score to the console
            //Debug.Log("Score: " + score);

            // Disable the Coin GameObject
            other.gameObject.SetActive(false);
        }

        // Check if the Player collides with an object tagged "Trap"
        else if (other.gameObject.CompareTag("Trap"))
        {
            // Decrement the health when hitting a trap
            health--;

            // Update the HealthText UI
            SetHealthText();

            // Log the updated health to the console
            // Debug.Log("Health: " + health);
        }

        // Check if the Player collides with an object tagged "Goal"
        else if (other.gameObject.CompareTag("Goal"))
        {
            // Display "You Win!" in the WinLoseText UI
            winLoseText.text = "You Win!";
            winLoseText.color = Color.black; // Set text color to black

            // Change WinLoseBG color to green
            winLoseBG.color = Color.green;

            // Activate the WinLoseBG GameObject
            winLoseBG.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        // Check if the health equals 0
        if (health <= 0)
        {
            // Display Game Over in the WinLoseText UI
            winLoseText.text = "Game Over!";
            winLoseText.color = Color.white;

            // Change WinLoseBG to red
            winLoseBG.color = Color.red;

            // Activate the WinLoseBG GameObject
            winLoseBG.gameObject.SetActive(true);

            // Reload the current scene (restarts the game)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // Reset health and score to their initial values
            health = initialHealth;
            score = initialScore;

            // Update the ScoreText UI
            SetScoreText();
            // Update the HealthText UI
            SetHealthText();
        }
    }

    // Method to update the ScoreText UI
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Method to update the HealthText UI
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
