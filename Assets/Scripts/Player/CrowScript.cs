
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

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
    [SerializeField]
    public GameObject GroundCheckGameObject;
    [SerializeField] private Transform groundCheck; 
    [SerializeField] private float checkRadius = 0.9f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Push/Pull")]
    [SerializeField] private float distance = 1f;
    [SerializeField] private LayerMask InteractMask;
    private GameObject box;
    private bool isPushingOrPulling = false; //state for pushing/pulling

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        //move the player left and right (MOVEMENT)
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        
        
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

        // Flip the sprite based on the direction the player is moving (VISUAL)
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // Facing right
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f); // Facing left
        }

        // Perform a raycast below the player to check for pushable objects
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance, InteractMask);

        // If a pushable object is detected and the player presses "E", attach it to the player using a FixedJoint2D
        if (hit.collider != null && hit.collider.CompareTag("Pushable") && Input.GetKeyDown(KeyCode.E))
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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        // Check if the player is on the ground 
    }
}
