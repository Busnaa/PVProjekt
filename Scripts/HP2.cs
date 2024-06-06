using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP2 : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private SpriteRenderer spriteRenderer;
    public Sprite normalSprite;
    public Sprite takeDamadgeSprite;
    public Sprite Dead;
    public Sprite defenseSprite;
    public float hitDuration = 0.5f;
    public HealthBar healthBar;
    private GameManager gameManager;
    private Movewasd Movewasd;
    public bool blocking;
    public Slider stamina;
    public float staminaDrainRate = 4.0f;
    public float rechargeDelay = 3.0f;
    private float timeSinceLastBlock = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        stamina.maxValue = 100;
        stamina.value = 100;
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalSprite;
        healthBar.SetMaxHealth(maxHealth);
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
        if (Input.GetKeyDown(KeyCode.M) && stamina.value > 1)
        {
            spriteRenderer.sprite = defenseSprite;
            blocking = true;
            timeSinceLastBlock = 0.0f;

        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            spriteRenderer.sprite = normalSprite;
            blocking = false;
        }
        if (blocking && stamina.value > 0)
        {
            stamina.value -= staminaDrainRate * Time.deltaTime;
        }
        if (!blocking)
        {
            timeSinceLastBlock += Time.deltaTime;
            if (timeSinceLastBlock >= rechargeDelay)
            {

                stamina.value = Mathf.Min(stamina.value + (staminaDrainRate * Time.deltaTime), stamina.maxValue);
            }
        }
        if (stamina.value < 1)
        {
            blocking = false;
        }
    }
    // Reduces the health of the object by the specified damage amount
    public void takeDamadge(int Damadge)
    {
        if (blocking == false)
        {


            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                currentHealth -= Damadge;

                StartCoroutine(damadgeHit());
                healthBar.SetHealth(currentHealth);
            }
        }
    }
    // Handles the death of the object
    private void Die()
    {
        spriteRenderer.sprite = Dead;
       
        GetComponent<Movesipky>().enabled = false;
        gameManager.PlayertwoDied();
        Movewasd.Changewin();
    }

    // Displays a temporary "take damage" visual effect
    private System.Collections.IEnumerator damadgeHit()
    {
        spriteRenderer.sprite = takeDamadgeSprite;
        yield return new WaitForSeconds(hitDuration);
        spriteRenderer.sprite = normalSprite;
    }
}