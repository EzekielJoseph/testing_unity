using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement; // Reference to the PlayerMovement script


    private void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            FindObjectOfType<GameManager>().CompleteLevel(); // Call CompleteLevel method from GameManager
            movement.StopMovement(); // Stop player movement
            //GetComponent<PlayerMovement>().enabled = false;   // Then disable movement script
            FindObjectOfType<Score>().StopScore();            // Stop the score from updating
            Debug.Log("Level Completed!");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver(); // Call GameOver method from GameManager
            movement.StopMovement(); // Stop player movement
            Debug.Log("Game Over! Collision with obstacle.");
        }
    }
}