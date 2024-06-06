using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public float followDistance = 2f; // Distance at which the AI stops following
    public float speed = 5f; // Speed at which the AI moves

    private bool isFollowingPlayer = false;


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
                if (distance > followDistance)
                {
                    isFollowingPlayer = true;
                }
            }

            // Move the AI towards the player if it is following
            if (isFollowingPlayer)
            {
                transform.position += (Vector3)direction * speed * Time.deltaTime;
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
}