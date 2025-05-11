using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get movement input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();
    }

    void FixedUpdate()
    {
        // Set velocity
        rb.linearVelocity = input * moveSpeed;
    }
}
