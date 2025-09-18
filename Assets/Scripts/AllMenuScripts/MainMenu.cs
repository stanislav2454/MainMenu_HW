using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private const string GAME = "Game";

    public void Play()
    {
        SceneManager.LoadScene(GAME);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.LogWarning("Application.Quit");
    }
}