using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenuCanvas;
    //[SerializeField] private GameObject _pauseMenuCanvas;

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
    {//false, 1f
        ChangePauseState(false, 1f);
        //PauseMenuCanvas.SetActive(false);// todo
        //Time.timeScale = 1f;// todo
        //IsPaused = false;// todo    
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");// todo
    }

    private void Stop()
    {//true, 0f
        ChangePauseState(true, 0f);
    }

    private void ChangePauseState(bool pauseState, float timeScale)
    {
        PauseMenuCanvas.SetActive(pauseState);// todo
        Time.timeScale = timeScale;// todo
        IsPaused = pauseState;// todo
    }
}
