using UnityEngine;

public class PowerUpp : MonoBehaviour
{
    public float newCooldownTime = 0.2f;
    public GameObject hlava1;
    public GameObject hlava2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D called with: " + other.name);

        // Check if the collider belongs to Player1 or Player2
        if (other.CompareTag("Player1"))
        {
            Debug.Log("Player1 collided with power-up");
            hlava1.SetActive(true);

            // Find the PlayerCombat component and set the attackCooldownTime
            PlayerCombat playerCombat = other.GetComponent<PlayerCombat>();
            if (playerCombat != null)
            {
                playerCombat.SetAttackCooldownTime(newCooldownTime);
            }

            // Destroy the power-up
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player2"))
        {
            Debug.Log("Player2 collided with power-up");
            hlava2.SetActive(true);
            // Find the PlayerCombat2 component and set the attackCooldownTime
            PlayerCombat2 playerCombat2 = other.GetComponent<PlayerCombat2>();
            if (playerCombat2 != null)
            {
                playerCombat2.SetAttackCooldownTime(newCooldownTime);
            }

            // Destroy the power-up
            Destroy(gameObject);
        }
    }
}
