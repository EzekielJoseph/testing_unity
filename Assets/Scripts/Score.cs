using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;

    

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Mathf.FloorToInt(player.position.z).ToString();

        if(player.position.y < -1)
        {
            scoreText.text = "Game Over";
        }
    }
}