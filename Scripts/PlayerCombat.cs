using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class PlayerCombat : MonoBehaviour
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
    private bool canAttack = true;
    public HP hp;
   

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalSprite;
       
    }

    private void Update()
    {

        // Perform box attack when the 'C' key is pressed
        if (Input.GetKeyDown(KeyCode.C) && hp.blocking == false)
            {
            if (canAttack)
            {
                StartCoroutine(PerformBoxAttack());
                canAttack = false;
                StartCoroutine(AttackCooldownTimer());
            }
            // Perform leg attack when the 'V' key is pressed
        }
        if (Input.GetKeyDown(KeyCode.V) && hp.blocking == false)
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
        Collider2D[] hitEnemies;
        hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<HP2>().takeDamadge(attactDamadge);
        }
        // Update sprite to show the box attack animation
        spriteRenderer.sprite = attackBoxSprite;
        yield return new WaitForSeconds(attackDuration);
        spriteRenderer.sprite = normalSprite;
       

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
            enemy.GetComponent<HP2>().takeDamadge(attactDamadge);
        }

    }

    public void SetAttackCooldownTime(float newCooldownTime)
    {
        attackCooldownTime = newCooldownTime;
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a sphere gizmo to visualize the attack range
        if (attackPoint == null){
            return;
        }
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
