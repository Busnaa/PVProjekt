using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movesipky : MonoBehaviour
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

    public BoxCollider2D Collider;

    public Vector2 standingSize;
    public Vector2 crouchingSize;


    

    
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        Move = 0;
       
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = standing;
        standingSize = Collider.size;

    }

    // Update is called once per frame
    void Update()
    {

        

        


        rb.velocity = new Vector2(speed * Move, rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move = 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move = -1;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Move = 0;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Move = 0;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            spriteRenderer.sprite = crouching;
            Collider.enabled = false;
            speed = speed / 2;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            spriteRenderer.sprite = standing;
            Collider.enabled = true;
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

   
    
}
