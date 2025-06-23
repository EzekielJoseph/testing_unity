using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
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
}
