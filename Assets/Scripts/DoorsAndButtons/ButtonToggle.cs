using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    [SerializeField]
    private int buttonID;
    private DoorToggle door;
    void Start()
    {
        DoorToggle[] doors = FindObjectsOfType<DoorToggle>();
        foreach (DoorToggle d in doors)
        {
            if (d.doorTID == buttonID)
            {
                door = d;
                break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && door != null)
        {
            door.ToggleDoor(); //buka pintu
        }
    }
}
