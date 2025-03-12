using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHold : MonoBehaviour
{
    public bool isHolding = false;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player is holding the button");
            isHolding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player is not holding the button");
            isHolding = false;
        }
    }
}
