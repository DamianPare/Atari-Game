using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector2 movement; // Store movement input

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    private void Update()
    {
        // Reset movement vector
        movement = Vector2.zero;

        // Get input from keyboard for WASD keys
        if (Input.GetKey(KeyCode.W)) movement.y = 1f; // Move up
        if (Input.GetKey(KeyCode.S)) movement.y = -1f; // Move down
        if (Input.GetKey(KeyCode.A)) movement.x = -1f; // Move left
        if (Input.GetKey(KeyCode.D)) movement.x = 1f; // Move right
    }

    private void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
