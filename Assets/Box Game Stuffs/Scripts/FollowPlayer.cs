using UnityEngine;

public class FollowCamera : MonoBehaviour
{ 
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset from the player's position

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}
