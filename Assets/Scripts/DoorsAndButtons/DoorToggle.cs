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
    private Vector3 initialPos;
    [SerializeField]
    private Vector3 desiredPos;
    [SerializeField]
    private Vector3 offsetPos = new Vector3(0, 3f, 0); // Example offset for open position
    [Header("Door Speed")]
    public float speed = 2f;
    [Header("Door State")]
    public bool isOpen = false;

    void Start()
    {
        initialPos = transform.position;
        // closedposToggle = transform.position;
        // openPosToggle = closedposToggle + new Vector3(0, 3f, 0); // Example offset for open position
    }

    void Update()
    {
        Vector3 targetPosition = initialPos + desiredPos;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    public void OpenDoor()
    {
        Debug.Log("Open Door");
        desiredPos = offsetPos;
    }

    public void CloseDoor()
    {
        Debug.Log("Close Door");
        desiredPos = Vector3.zero;
    }
}

