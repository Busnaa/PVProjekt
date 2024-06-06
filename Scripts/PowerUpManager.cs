using System.Collections;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject powerUp; // Reference to the power-up GameObject
    public float delay = 5f;   // Delay in seconds before the power-up appears

    private void Start()
    {
        // Make sure the power-up is initially inactive
        powerUp.SetActive(false);
        // Start the coroutine to activate the power-up after a delay
        StartCoroutine(ActivatePowerUpAfterDelay());
    }

    private IEnumerator ActivatePowerUpAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        // Activate the power-up
        powerUp.SetActive(true);
    }
}
