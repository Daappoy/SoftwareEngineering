using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public ButtonController button;
    [Header("Door Position")]
    public Vector3 openPos;
    public Vector3 closedpos;
    [Header("Door Speed")]
    public float speed = 2f;
    [Header("Door State")]
    public bool isOpen = false;

    void Start()
    {
       closedpos = transform.position;
    }

    void Update()
    {
        Vector3 targetPosition;
        if(isOpen)
        {
            Debug.Log("Open Door");
            targetPosition = openPos;
        }
        else
        {
            Debug.Log("Close Door");
            targetPosition = closedpos;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

    }
    public void ToggleDoor()
    {
        Debug.Log("Toggle Door");
        isOpen = !isOpen;
    }

    public void MoveDoor()
    {
        if(button.isHolding == true)
        {
            
        }
    }
}
