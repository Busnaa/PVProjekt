using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI winText;
    private bool end = false;
    public string sceneName;
    public float delayInSeconds = 5f;

    // Sets the winText to indicate Player One's death
    public void PlayerOneDied()
    {
        winText.text = "PLAYER TWO WINS!";
        end = true;
    }

    // Sets the winText to indicate Player Two's death
    public void PlayertwoDied()
    {
        winText.text = "PLAYER ONE WINS!";
        end = true;
    }

    // Sets the winText to indicate a draw due to time's up
    public void TimesUp()
    {
        winText.text = "TIMES UP DRAW!";
        end = true;
    }

    // Checks if the game has ended and changes the scene after a delay
    public void Update()
    {
        if (end)
        {
            Invoke("ChangeSceneWithDelay", delayInSeconds);
        }
    }

    // Changes the scene after the specified delay
    private void ChangeSceneWithDelay()
    {
        SceneManager.LoadScene(sceneName);
    }
}

