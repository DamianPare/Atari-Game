using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector2 movement; // Store movement input
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    private void Update()
    {
        // Reset movement vector
        movement = Vector2.zero;

        if (movement.y == 0 && movement.x == 0)
        {
            animator.SetBool("isMoving?", false);
        }

        // Get input from keyboard for WASD keys
        if (Input.GetKey(KeyCode.W))  // Move up
        {
            animator.SetBool("isMoving?", true);
            movement.y = 1f;
        }

        if (Input.GetKey(KeyCode.S))  // Move down
        {
            animator.SetBool("isMoving?", true);
            movement.y = -1f;
        }

        if (Input.GetKey(KeyCode.A))  // Move left
        {
            animator.SetBool("isMoving?", true);
            spriteRenderer.flipX = true;
            movement.x = -1f;
        }
        
        if (Input.GetKey(KeyCode.D))  // Move right
        {
            animator.SetBool("isMoving?", true);
            spriteRenderer.flipX = false;
            movement.x = 1f;
        }   
    }

    private void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
