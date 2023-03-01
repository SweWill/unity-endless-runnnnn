using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public int maxJumps = 2;
    private int jumpsRemaining;
    private bool isGrounded;
    private Rigidbody2D rb;
    private bool facingRight = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal, 0, 0) * moveSpeed * Time.deltaTime;

        if (horizontal > 0 && !facingRight) // if moving right and not facing right, flip sprite
        {
            Flip();
        }
        else if (horizontal < 0 && facingRight) // if moving left and facing right, flip sprite
        {
            Flip();
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontal * moveSpeed));

        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpsRemaining--;

            animator.SetBool("IsJumping", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            jumpsRemaining = maxJumps;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
