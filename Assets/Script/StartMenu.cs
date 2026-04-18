using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void mainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void credits()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
