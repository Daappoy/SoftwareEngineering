using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class AttachController : MonoBehaviour
{

    [Header("FoxScriptAndAttach")]
    [SerializeField] public  Rigidbody2D foxRb; 
    [SerializeField] private Transform foxTransform;
    private Vector3 crowOffset = new Vector3(0f, 1f, 0f);

    [Header("crowScript")]
    [SerializeField] public CrowScript crowScript;
    [SerializeField] public BoxCollider2D crowCollider;
    [SerializeField] public Rigidbody2D CrowRb;
    [SerializeField] public bool isAttached = false;
    [SerializeField] private Transform crowTransform;

    [Header("Player Switch")]
    public PlayerSwitch playerSwitchScript;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Crow") && playerSwitchScript.isFox == true && isAttached == false)
        {
            AttachToFox();
            Debug.Log("Attached to crow as a fox");
        }
        if (collision.gameObject.CompareTag("Player") && playerSwitchScript.isFox == false )
        {
            Debug.Log("attached to fox as a crow");
            AttachToFox();
            //Switch control to fox
            playerSwitchScript.SwitchPlayer();
        }
    }
    public void AttachToFox()
    {
        isAttached = true;
        CrowRb.mass = 0;
        crowTransform.transform.parent = foxTransform;
        crowCollider.enabled = false; 
    }

    public void DetachFromFox()
    {
        Debug.Log("detached from fox, now playing as a crow");
        isAttached = false;
        CrowRb.mass = 1;
        crowTransform.transform.parent = null;
        crowScript.OnDetachBoost();
        crowCollider.enabled = true; 
    }  

    void Update()
    {
        if (isAttached && Input.GetKeyDown(KeyCode.Q))
        {
            DetachFromFox();
        }
        if (isAttached)
        {
            crowTransform.position = foxTransform.position + crowOffset;
        }
    }
}
