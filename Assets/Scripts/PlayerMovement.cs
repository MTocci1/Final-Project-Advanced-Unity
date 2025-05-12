using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 input;
    private Vector2 lastMoveDir;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get movement input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();

        // Determine and store last dominant move direction
        if (input != Vector2.zero)
        {
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                lastMoveDir = new Vector2(input.x, 0); // Horizontal priority
            else
                lastMoveDir = new Vector2(0, input.y); // Vertical priority

            // Flip sprite if moving horizontally
            if (lastMoveDir.x != 0)
                spriteRenderer.flipX = lastMoveDir.x < 0;
        }

        // Update animator
        animator.SetBool("isMoving", input.sqrMagnitude > 0);
        animator.SetFloat("moveX", lastMoveDir.x);
        animator.SetFloat("moveY", lastMoveDir.y);
    }

    void FixedUpdate()
    {
        // Set velocity
        rb.linearVelocity = input * moveSpeed;
    }
}
