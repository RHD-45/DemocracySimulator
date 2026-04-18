using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    private int playerScore;
    [SerializeField] Text scoreText;

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }
}
