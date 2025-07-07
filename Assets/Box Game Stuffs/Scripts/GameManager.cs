using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1.5f; // Time before the game restarts



    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject finalScore;

    public void CompleteLevel()
    {
        winPanel.SetActive(true);
        losePanel.SetActive(false);
        finalScore.SetActive(true);
    }

    public void GameOver()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            winPanel.SetActive(false);
            losePanel.SetActive(true);
            finalScore.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
