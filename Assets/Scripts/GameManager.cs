using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1.5f; // Time before the game restarts

    public GameObject completeLevelUI; // UI to show when the level is completed

    public void CompleteLevel()
    {
;        completeLevelUI.SetActive(true); 
    }

    public void GameOver()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke ("Restart", restartDelay );
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
