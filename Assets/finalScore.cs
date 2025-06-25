using UnityEngine;
using TMPro;

public class finalScore : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText; // Assign this in the Inspector

    void OnEnable()
    {
        // Get the Score script and display the final score
        Score scoreScript = FindObjectOfType<Score>();
        if (scoreScript != null && finalScoreText != null)
        {
            int finalScore = scoreScript.FinalScore; 
            finalScoreText.text = "Score: " + scoreScript.FinalScore.ToString();

            test serialScript = FindObjectOfType<test>();
            if (serialScript != null)
            {
                serialScript.score = finalScore; // Update the score in the test script
                serialScript.SendFinalScore(finalScore); // Send the final score to the ESP32
            }
        }
    }
}