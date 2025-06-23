using UnityEngine;

public class PlayerCollision : MonoBehaviour
{     
    public PlayerMovement movement; // Reference to the PlayerMovement script


    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            GetComponent<PlayerMovement>().enabled = false; // Disable player movement on collision
            FindObjectOfType<GameManager>().GameOver(); // Call GameOver method from GameManager
        }
           
        if (collisionInfo.collider.tag == "Finish")
        {
            FindObjectOfType<GameManager>().CompleteLevel(); // Call CompleteLevel method from GameManager
            Debug.Log("Level Completed!");
        }

    } 
}
