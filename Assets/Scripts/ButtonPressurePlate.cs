using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ButtonPressurePlate : MonoBehaviour
{
    private bool pressed = false;
    public GameObject Sprite;
    private Vector3 originalPos;
    public GameObject door;
    private Vector3 doorOriginalPos;
    private Doorvariables DV;

    private void Start()
    {
        originalPos = Sprite.transform.position;
        doorOriginalPos = door.transform.position;
        DV = door.GetComponent<Doorvariables>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("touched");
        if (collision.tag == "Player")
        {
            Debug.Log("touched");
            pressed = true;
            Sprite.transform.position = new Vector3(originalPos.x, originalPos.y - 0.3f, originalPos.z);
            DV.isOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("untouched");
            pressed = false;
            Sprite.transform.position = originalPos;
            DV.isOpen = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            opendoor();
        }
    }

    private void opendoor()
    {
        if (door.transform.position.y > doorOriginalPos.y - 4)
        {
            door.transform.Translate(0, - 0.5f, 0);
        }
    }

    private void FixedUpdate()
    {
        
        if (door.transform.position.y < doorOriginalPos.y && !DV.isOpen)
        {
            Debug.Log("up");
            door.transform.Translate(0, 0.01f, 0);
        }
    }
}
