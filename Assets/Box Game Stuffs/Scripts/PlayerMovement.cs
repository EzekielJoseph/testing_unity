using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public bool isMoving = true; // Flag to check if the player is moving

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if (!isMoving) return; // If not moving, skip the rest of the method


        rb.AddForce(0, 0, forwardForce * Time.deltaTime); // Move forward

        if ( Input.GetKey("d") ) { 
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); // Move right
        }

        if ( Input.GetKey("a") ) { 
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); // Move left
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().GameOver(); // Call GameOver method from GameManager if player falls below a certain height
        }
    }

    public void MoveLeft()
    {
        rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void MoveRight()
    {
        rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void StopMovement()
    {
        rb.velocity=Vector3.zero; // Stop all momentum
        rb.angularVelocity = Vector3.zero; // Stop all rotation
        isMoving = false;
        Debug.Log("Player movement stopped.");
    }
}
