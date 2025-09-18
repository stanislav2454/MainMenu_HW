using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenuCanvas;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    public void Play()
    {
        ChangePauseState(false, 1f);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");// todo
    }

    private void Stop()
    {
        ChangePauseState(true, 0f);
    }

    private void ChangePauseState(bool pauseState, float timeScale)
    {
        PauseMenuCanvas.SetActive(pauseState);
        Time.timeScale = timeScale;
        IsPaused = pauseState;
    }
}
