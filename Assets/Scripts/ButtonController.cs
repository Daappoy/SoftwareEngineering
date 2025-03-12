using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool isHolding = false;

    public Door door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            door.ToggleDoor(); //buka pintu
        }
    }

    private void OTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isHolding = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isHolding = false;
        }
    }
}
