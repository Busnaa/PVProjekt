using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat2 : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite attackBoxSprite;
    public Sprite attackLegSprite;
    public float attackDuration = 0.5f;

    private SpriteRenderer spriteRenderer;

    public Transform attackPoint;               // Position where the box attack originates from
    public Transform attackPointLeg;            // Position where the leg attack originates from
    public LayerMask enemyLayers;               // Layers to detect for enemy collision
    public float attackRange = 0.5f;            // Radius of the attack range
    public int attactDamadge = 40;              // Damage inflicted on enemies
    public float attackCooldownTime = 1f;       // Time between consecutive attacks
    private bool canAttack = true;              // Flag indicating if the player can perform an attack
    public HP2 hp;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalSprite;
    }

    private void Update()
    {

        // Perform box attack when the ',' key is pressed
        if (Input.GetKeyDown(KeyCode.Comma) && hp.blocking == false)
        {
            if (canAttack)
            {
                StartCoroutine(PerformBoxAttack());
                canAttack = false;
                StartCoroutine(AttackCooldownTimer());
            }
        }
        // Perform leg attack when the '.' key is pressed
        if (Input.GetKeyDown(KeyCode.Period) && hp.blocking == false)
        {
            if (canAttack)
            {
                StartCoroutine(PerformLegAttack());
                canAttack = false;
                StartCoroutine(AttackCooldownTimer());
            }
        }

    }








    private System.Collections.IEnumerator PerformBoxAttack()
    {
        // Detect and damage enemies within the attack range
        spriteRenderer.sprite = attackBoxSprite;
        yield return new WaitForSeconds(attackDuration);
        spriteRenderer.sprite = normalSprite;
        Collider2D[] hitEnemies;

        hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<HP>().takeDamadge(attactDamadge);
        }


    }

    IEnumerator AttackCooldownTimer()
    {
        // Wait for the attack cooldown time before allowing the next attack

        yield return new WaitForSeconds(attackCooldownTime);

        
        canAttack = true;
    }

    private System.Collections.IEnumerator PerformLegAttack()
    {
        // Update sprite to show the leg attack animation
        spriteRenderer.sprite = attackLegSprite;
        yield return new WaitForSeconds(attackDuration);
        spriteRenderer.sprite = normalSprite;
        // Detect and damage enemies within the leg attack range
        Collider2D[] hitEnemies;
        hitEnemies = Physics2D.OverlapCircleAll(attackPointLeg.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<HP>().takeDamadge(attactDamadge);

        }
    }


    public void SetAttackCooldownTime(float newCooldownTime)
    {
        attackCooldownTime = newCooldownTime;
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a sphere gizmo to visualize the attack range
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
