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
    public Vector3 initialPos;
    [SerializeField]
    private Vector3 desiredPos;
    [SerializeField]
    public Vector3 offsetPos; // Example offset for open position
    [Header("Door Speed")]
    public float speed = 2f;
    [Header("Door State")]
    public bool isOpen = false;
    public bool isSideWay;

    void Start()
    {
        initialPos = transform.localPosition;;
        // closedposToggle = transform.position;
        // openPosToggle = closedposToggle + new Vector3(0, 3f, 0); // Example offset for open position
    }

    void Update()
    {
        Vector3 targetPosition = initialPos + desiredPos;

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);
    }
    [ContextMenu("OpenDoor")]
    public void OpenDoor()
    {
        Debug.Log("Open Door");
        desiredPos = offsetPos;
    }
    [ContextMenu("CloseDoor")]
    public void CloseDoor()
    {
        Debug.Log("Close Door");
        desiredPos = Vector3.zero;
    }
}

