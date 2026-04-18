using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    private int playerScore;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject endScreen;

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }

    void Awake()
    {
        endScreen.SetActive(false);
    }

    public void endGame()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Logic");
        Destroy(player);
        foreach (GameObject obj in spawners)
        {
            Destroy(obj);
        }
        endScreen.SetActive(true);
        scoreText.rectTransform.anchoredPosition = new Vector2(25,-16);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
