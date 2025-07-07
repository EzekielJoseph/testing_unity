using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    void OnTriggerEnter()
    {
        FindAnyObjectByType<GameManager>().CompleteLevel(); 
        Debug.Log("Level Completed! end");
    }

}
