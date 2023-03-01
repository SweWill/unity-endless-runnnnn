// Script that controls the player character
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Reference to the Animator component for the player character
    public Animator animator;
    // Movement speed of the player character
    public float moveSpeed = 5f;

    // Jump force of the player character
    public float jumpForce = 5f;

    // Maximum number of jumps the player character can perform before landing
    public int maxJumps = 2;

    // Number of jumps remaining for the player character
    private int jumpsRemaining;

    // Boolean that determines if the player character is grounded or not
    private bool isGrounded;

    // Reference to the Rigidbody2D component for the player character
    private Rigidbody2D rb;

    // Boolean that determines if the player character is facing right or left
    private bool facingRight = true;

    void Start()
    {
        // Get the Rigidbody2D component for the player character
        rb = GetComponent<Rigidbody2D>();

        // Set the number of jumps remaining to the maximum number of jumps
        jumpsRemaining = maxJumps;
    }

    void Update()
    {
        // Get the horizontal and vertical input axis values
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Move the player character horizontally
        transform.position += new Vector3(horizontal, 0, 0) * moveSpeed * Time.deltaTime;

        // Check if the player character is moving right and not facing right, or moving left and facing right, and flip the sprite accordingly
        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontal < 0 && facingRight)
        {
            Flip();
        }

        // Set the "Speed" parameter of the Animator component based on the player character's horizontal movement speed
        animator.SetFloat("Speed", Mathf.Abs(horizontal * moveSpeed));

        // Check if the player character has pressed the jump button and has jumps remaining
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            // Apply a vertical velocity to the player character's Rigidbody2D component to initiate a jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            // Decrement the number of jumps remaining
            jumpsRemaining--;

            // Set the "IsJumping" parameter of the Animator component to true
            animator.SetBool("IsJumping", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player character has collided with a game object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Set the isGrounded boolean to true
            isGrounded = true;

            // Set the "IsJumping" parameter of the Animator component to false
            animator.SetBool("IsJumping", false);

            // Reset the number of jumps remaining to the maximum number of jumps
            jumpsRemaining = maxJumps;
        }
    }

    // Method that flips the sprite of the player character
    void Flip()
    {
        // Invert the facingRight boolean
        facingRight = !facingRight;

        // Get the local scale of the player character
        Vector3 theScale = transform.localScale;

        // Invert the x component of the local scale to flip the sprite horizontally
        theScale.x *= -1;

        // Set the local scale of the player character to the updated scale
        transform.localScale = theScale;
    }
}