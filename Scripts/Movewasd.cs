using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movewasd : MonoBehaviour
{
    public float speed;
    private float Move;
    private float Move2;
    private Rigidbody2D rb;
    public float jump;
    public bool isJumping;
    public SpriteRenderer spriteRenderer;

    public Sprite standing;
    public Sprite crouching;
    public Sprite win;
    bool crouch = false;

    public BoxCollider2D collider;

    public Vector2 standingSize;
    public Vector2 crouchingSize;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Move = 0;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = standing;
        standingSize = collider.size;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.D))
        {
            Move = 1;

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Move = 0;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Move = -1;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            Move = 0;
        }

        if (Input.GetKeyDown(KeyCode.W) && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        if (Input.GetKeyDown(KeyCode.S))

        {
            speed = speed / 2;
            spriteRenderer.sprite = crouching;
            collider.enabled = false;
            crouch = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            spriteRenderer.sprite = standing;
            collider.enabled = true;
            crouch = false;
            speed = speed * 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    public void Changewin()
    {
        spriteRenderer.sprite = win;

    }
}
