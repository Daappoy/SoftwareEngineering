using Unity.VisualScripting;
using UnityEngine;

public class FoxScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float Horizontal;
    private bool isJumping = false;
    private bool isGrounded = false; 
    private bool isPushingOrPulling = false; //state for pushing/pulling
    private bool IsWallSliding = false;
    private bool IsWallJumping = false;
    private float WallJumpingDirection;
    private bool IsFacingRight = true;

    [Header("Player Movement")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float reducedSpeed = 2f; //Slower speed when pushing/pulling
    [SerializeField] private float jumpingPower = 7f;
    

    [Header("Ground/Wall Check")]
    [SerializeField] private Transform groundCheck; 
    [SerializeField] private float groundcheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform WallCheck;
    [SerializeField] private float wallcheckRadius = 0.9f;
    [SerializeField] private LayerMask WallLayer;

    [Header("Push/Pull")]
    [SerializeField] private float distance = 1f;
    [SerializeField] private LayerMask InteractMask;
    private GameObject box;

    [Header("WallJump")]
    [SerializeField] private float WallJumpingTime = 0.2f;
    [SerializeField] private float WallSlidingSpeed = 2f;
    [SerializeField] private float WallJumpCounter = 0;
    [SerializeField] private float WallJumpDuration = 0.4f;
    [SerializeField] private Vector2 WallJumpingPower = new Vector2(8f, 16f);




    private void Start()
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

        WallSlide();
        WallJump();
    }

    private void FixedUpdate()
    {
        Move();       
        CheckGround();
    }

    private void Flip()
    {
        // Flip character when changing direction
        if (IsFacingRight && Horizontal < 0f || !IsFacingRight && Horizontal > 0f)
        {
            IsFacingRight = !IsFacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;

        }
    }

    private void Move()
    {
        if (!IsWallJumping)
        {
            rb.velocity = new Vector2(Horizontal * speed, rb.velocity.y);
        }

        Flip();

        
    }

    private void ProcessInputs()
    {

        Horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && !isPushingOrPulling && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetKeyUp(KeyCode.Space) && !isPushingOrPulling && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundcheckRadius, groundLayer);
        return isGrounded;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(WallCheck.position, wallcheckRadius, WallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !CheckGround() && Horizontal != 0f) 
        {
            IsWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -WallSlidingSpeed, float.MaxValue));
        }
        else
        {
            IsWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (IsWallSliding) 
        {
            WallJumpingDirection = IsFacingRight ? -1f : 1f; // Ensure direction is set correctly
            IsWallJumping = false;
            WallJumpCounter = WallJumpingTime;
            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            WallJumpCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && WallJumpCounter > 0f)
        {
            IsWallJumping = true;



            // Apply the jump force
            rb.velocity = new Vector2(WallJumpingDirection * WallJumpingPower.x, WallJumpingPower.y);
            WallJumpCounter = 0f;

            // Ensure the player faces the correct direction after jumping
            if ((WallJumpingDirection > 0 && !IsFacingRight) || (WallJumpingDirection < 0 && IsFacingRight))
            {
                Flip();
            }

            Invoke(nameof(StopWallJumping), WallJumpDuration);
        }

    }

    private void StopWallJumping()
    {
        IsWallJumping = false; // Allow movement again
    }
}
