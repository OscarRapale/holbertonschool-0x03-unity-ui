using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 7f; // Public variable to control speed
    public int health = 5; // Public variable for health
    private int initialHealth; // Store initial health for reset
    private int score = 0; // Player score
    private int initialScore; // Store initial score for reset


    // Rigidbody component reference
    private Rigidbody rb;

    void Start()
    {
        // Save the initial values for health and score to reset later
        initialHealth = health;
        initialScore = score;

        // Get the Rigidbody component attached to the Player
        rb = GetComponent<Rigidbody>();
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

            // Log the updated score to the console
            Debug.Log("Score: " + score);

            // Disable the Coin GameObject
            other.gameObject.SetActive(false);
        }

        // Check if the Player collides with an object tagged "Trap"
        else if (other.gameObject.CompareTag("Trap"))
        {
            // Decrement the health when hitting a trap
            health--;

            // Log the updated health to the console
            Debug.Log("Health: " + health);
        }

        // Check if the Player collides with an object tagged "Goal"
        else if (other.gameObject.CompareTag("Goal"))
        {
            // Display "You win!" message in the console
            Debug.Log("You win!");
        }
    }

    void Update()
    {
        // Check if the health equals 0
        if (health <= 0)
        {
            // Log the game over message
            Debug.Log("Game Over!");

            // Reload the current scene (restarts the game)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // Reset health and score to their initial values
            health = initialHealth;
            score = initialScore;
        }
    }
}
