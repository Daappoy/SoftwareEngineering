
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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            
        }
    }
}
