using UnityEngine;

public class AI2 : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public float followDistance = 2f; // Distance at which the AI stops following
    public float speed = 5f; // Speed at which the AI moves

    private bool isFollowingPlayer = false;
    private bool isPlayerInsideAI = false;
    private float flyAwayTimer = 4f;
    private bool isFlyingAway = false;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            float distance = Vector2.Distance(transform.position, target.position);
            direction.Normalize();

            if (isFollowingPlayer)
            {
                // AI is already following, check if it needs to stop
                if (distance <= followDistance)
                {
                    isFollowingPlayer = false;
                }
            }
            else
            {
                // AI is not following, check if it needs to start following
                if (distance > followDistance && !isPlayerInsideAI)
                {
                    isFollowingPlayer = true;
                }
            }

            // Move the AI towards the player if it is following
            if (isFollowingPlayer)
            {
                transform.position += (Vector3)direction * speed * Time.deltaTime;
            }

            // Check if the player is inside the AI
            if (isPlayerInsideAI)
            {
                flyAwayTimer += Time.deltaTime;

                // Check if it's time to fly away
                if (flyAwayTimer >= 5f && !isFlyingAway)
                {
                    FlyAway();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Ignore the collision with the player
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isPlayerInsideAI = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isPlayerInsideAI = false;
            flyAwayTimer = 0f;
        }
    }

    private void FlyAway()
    {
        isFlyingAway = true;
        // Implement your logic for AI flying away, e.g., changing position, enabling/disabling components, etc.
        // For example, you can use transform.Translate or transform.position to move the AI away from its current position.
    }
}