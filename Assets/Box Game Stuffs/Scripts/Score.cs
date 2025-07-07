using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;

    private bool isScoreActive = true;
    private int lastScore = 0; // Store the last score

    public int FinalScore => lastScore; // Public property to access the score

    private void Start()
    {
        scoreText.text = "0";
    }

    public void StopScore() => isScoreActive = false;   

    void Update()
    {
        if (!isScoreActive)
            return;

        lastScore = Mathf.FloorToInt(player.position.z); // Update lastScore
        scoreText.text = lastScore.ToString();

        if(player.position.y < -1)
        {
            scoreText.text = "Game Over";        }
    }
}