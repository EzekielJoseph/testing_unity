using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    void LoadNextLevel()
    {         // Load the next level in the build settings
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex + 1);
    }
}

