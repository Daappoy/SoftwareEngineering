
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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       float horizontalInput = Input.GetAxis("Horizontal");
       rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);  


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
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isFlying = true;
            rb.velocity = Vector2.up * flyStrength;
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            // rb.gravityScale = 0.1f;
        }
        else 
        {
            rb.gravityScale = 1f;
            isFlying = false;
        }
    }
}
