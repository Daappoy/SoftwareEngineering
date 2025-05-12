
using UnityEngine;

public class CrowScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private bool isFlying = false;
    [SerializeField]
    private bool isGrounded = false;
    [SerializeField]
    private bool isGrabItem = false;

    [Header("crow Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] public float flyStrength = 5f; 

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck; 
    [SerializeField] private float checkRadius = 0.9f;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * flyStrength;
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            rb.gravityScale = 0.1f;
        }
        else 
        {
            rb.gravityScale = 1f;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        // Check if the player is on the ground
       float horizontalInput = Input.GetAxis("Horizontal");
       
       //move the player left and right (MOVEMENT)
       if(isFlying)
        {
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        }
        

        // Flip the sprite based on the direction the player is moving (VISUAL)
       if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // Facing right
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f); // Facing left
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isFlying = false;
            // speed = 0f; // Stop the player when on the ground
            rb.velocity = new Vector2(0, rb.velocity.y); // Keep the vertical velocity
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isFlying = true;
            // speed = 3f; // Resume the player speed when leaving the ground
            
        }
    }
}
