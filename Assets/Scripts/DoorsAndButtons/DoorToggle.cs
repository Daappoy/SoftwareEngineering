using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorToggle : MonoBehaviour
{
    [Header("Door Toggle")]
    [SerializeField] private int DoorTID;
    public int doorTID => DoorTID;
    private ButtonToggle buttonToggle;
    [Header("Door Position")]
    [SerializeField]
    private Vector3 openPosToggle;
    [SerializeField]
    private Vector3 closedposToggle;
    [Header("Door Speed")]
    public float speed = 2f;
    [Header("Door State")]
    private bool isOpen = false;

    void Start()
    {
    //    closedposToggle = transform.position;
    }

    void Update()
    {
        Vector3 targetPosition;
        if(isOpen)
        {
            Debug.Log("Open Door");
            targetPosition = openPosToggle;
        }
        else
        {
            // Debug.Log("Close Door");
            targetPosition = closedposToggle;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

    }
    public void ToggleDoor()
    {
        Debug.Log("Toggle Door");
        isOpen = !isOpen;
    }
}
