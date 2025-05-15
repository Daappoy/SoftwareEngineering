using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{

    public bool beingPushed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!beingPushed)
        {
            // Freeze X movement to keep the box stationary
            // rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        } else
        {
            // Unfreeze X movement when being pushed
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
