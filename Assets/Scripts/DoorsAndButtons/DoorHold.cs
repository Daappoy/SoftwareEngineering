using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHold : MonoBehaviour
{
    [Header("Door Hold ID")]
    [SerializeField]
    private int doorHID;
    public int DoorHID => doorHID;
    public ButtonHold buttonHold;
    [Header("Door Position")]
    public Vector3 openPosHold;
    public Vector3 closedposHold;
    [Header("Door Speed")]
    public float speed = 2f;
    [Header("Door State")]
    private bool isOpen = false;
    void Start()
    {
        ButtonHold[] buttons = FindObjectsOfType<ButtonHold>();
        foreach (ButtonHold b in buttons)
        {
            if (b.buttonHID == doorHID)
            {
                buttonHold = b;
                break;
            }
        }
        closedposHold = transform.position;
    }

    void Update()
    {
        if(buttonHold.isHolding == true)
        {
            OpenDoorHold();
        }
        else
        {
            CloseDoorHold();
        }
    }

    public void OpenDoorHold()
    {
        if(buttonHold.isHolding == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosHold, speed * Time.deltaTime);
        }
    }
    public void CloseDoorHold()
    {
        if(buttonHold.isHolding == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, closedposHold, speed * Time.deltaTime);
        }
    }
}
