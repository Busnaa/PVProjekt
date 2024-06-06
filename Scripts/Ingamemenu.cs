using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ingamemenu : MonoBehaviour
{
    public GameObject menuPanel;
    public Button resumeButton;
    public Button restartButton;
    public Button quitButton;

    private bool isPaused = false;

    private void Start()
    {
        // Add click listeners to the buttons
        resumeButton.onClick.AddListener(ResumeGame);
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Pauses the game
    public void PauseGame()
    {
        Time.timeScale = 0f;
        menuPanel.SetActive(true);
        isPaused = true;
    }

    // Resumes the game
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
        isPaused = false;
    }

    // Restarts the game by reloading the current scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    // Quits the game
    public void QuitGame()
    {
        Application.Quit();
    }
}

