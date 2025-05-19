using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHold : MonoBehaviour
{
    [SerializeField]
    private int ButtonHID;
    public bool isHolding = false;

    void Start()
    {
        DoorHold[] doors = FindObjectsOfType<DoorHold>();
        foreach(DoorHold d in doors)
        {
            if(d.DoorHID == ButtonHID)
            {
                d.buttonHold = this;
                break;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Pushable"))
        {
            Debug.Log("Player is holding the button");
            isHolding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Pushable"))
        {
            Debug.Log("Player is not holding the button");
            isHolding = false;
        }
    }
}
