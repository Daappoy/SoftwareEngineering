using UnityEngine;

public class FoxScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded = false; 
    private bool isPushingOrPulling = false; //state for pushing/pulling

    [Header("Player Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float reducedSpeed = 2f; //Slower speed when pushing/pulling
    [SerializeField] private float jumpForce = 7f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck; 
    [SerializeField] private float checkRadius = 0.9f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Push/Pull")]
    [SerializeField] private float distance = 1f;
    [SerializeField] private LayerMask InteractMask;
    private GameObject box;




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessInputs();
        // Perform a raycast in the direction the player is facing to check for pushable objects
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, InteractMask);

        // If a pushable object is detected and the player presses "E", attach it to the player using a FixedJoint2D
        if (hit.collider != null && hit.collider.CompareTag("Pushable") &&Input.GetKeyDown(KeyCode.E))
        {
            isPushingOrPulling = true;
            box = hit.collider.gameObject;

            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<BoxPull>().beingPushed = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }   
        else if (Input.GetKeyUp(KeyCode.E)) // When the player releases "E", detach the object by disabling the FixedJoint2D
        {
            isPushingOrPulling = false;
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<BoxPull>().beingPushed = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
        CheckGround();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);

        // Flip character when changing direction
        if (moveDirection > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Facing right
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Facing left
        }

        if (isJumping && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = false; // Reset jump state
        }
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && !isPushingOrPulling && isGrounded)
        {
            isJumping = true;
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
