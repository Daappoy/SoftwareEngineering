using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    [SerializeField]
    private int buttonTID;
    private DoorToggle door;
    [SerializeField]
    public Sprite LeverOn;
    [SerializeField]
    public Sprite LeverOff;
    void Start()
    {
        DoorToggle[] doors = FindObjectsOfType<DoorToggle>();
        foreach (DoorToggle d in doors)
        {
            if (d.doorTID == buttonTID)
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
    private void FixedUpdate()
    {
        if (door.doorTID == buttonTID && door.isOpen == true)
        {
            // Change the button color to indicate it's pressed
            GetComponent<SpriteRenderer>().sprite = LeverOn;
        }
        else
        {
            // Reset the button color to its original state
            GetComponent<SpriteRenderer>().sprite = LeverOff;
        }
    }
    
}
