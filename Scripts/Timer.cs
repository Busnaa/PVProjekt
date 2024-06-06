using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f; // Total time in seconds
    public TextMeshProUGUI countdownText; // Reference to the countdown text
    private GameManager gameManager; // Reference to the game manager

    private float currentTime; // Current time remaining

    private void Start()
    {
        currentTime = totalTime;
        StartCoroutine(StartCountdown()); // Start the countdown
        gameManager = FindObjectOfType<GameManager>(); // Find the game manager object
    }

    private IEnumerator StartCountdown()
    {
        while (currentTime > 0)
        {
            UpdateCountdownText(); // Update the countdown text
            yield return new WaitForSeconds(1f); // Wait for 1 second
            currentTime--; // Decrease the current time
        }

        UpdateCountdownText(); // Update the countdown text one last time
        Debug.Log("Countdown finished!");
        gameManager.TimesUp(); // Call the TimesUp method in the game manager
    }

    private void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        string countdownString = string.Format("{0:00}:{1:00}", minutes, seconds);
        countdownText.text = countdownString; // Update the countdown text with the formatted time
    }
}

