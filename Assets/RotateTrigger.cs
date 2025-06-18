using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrigger : MonoBehaviour
{
    public PlayerSwitch playerSwitchScript;
    public RotatorScript rotatorScript;
    [SerializeField] private bool rotated = false;
    public BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        if (playerSwitchScript == null)
        {
            playerSwitchScript = FindObjectOfType<PlayerSwitch>();
        }
        if (rotatorScript == null)
        {
            rotatorScript = FindObjectOfType<RotatorScript>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !rotated && playerSwitchScript.isAttached == true)
        {
            rotatorScript.GameRotateLeft();
            rotated = true;
            boxCollider2D.enabled = false; // Disable the collider after rotation
        }
    }
}
