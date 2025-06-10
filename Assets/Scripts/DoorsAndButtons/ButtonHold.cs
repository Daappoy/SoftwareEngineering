using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonHold : MonoBehaviour
{
    [SerializeField]
    private int ButtonHID;
    public int buttonHID => ButtonHID;
    [SerializeField]
    private DoorHold doorHold;
    [SerializeField]
    public bool isHolding = false;

    public Sprite ButtonUnpressed;
    public Sprite ButtonPressed;
    public UnityEvent ButtonOn;
    public UnityEvent ButtonOff;

    void Start()
    {
        DoorHold[] doors = FindObjectsOfType<DoorHold>();
        foreach(DoorHold d in doors)
        {
            if(d.DoorHID == ButtonHID)
            {
                doorHold = d;
                break;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Pushable") && doorHold != null)
        {
            isHolding = true;
            GetComponent<SpriteRenderer>().sprite = ButtonPressed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Pushable"))
        {
            // if(doorHold.DoorHID == ButtonHID)
            // {
            //     Debug.Log("Player is not holding the button");
            //     isHolding = false;
            //     GetComponent<SpriteRenderer>().sprite = ButtonUnpressed;
            // }
            isHolding = false;
            GetComponent<SpriteRenderer>().sprite = ButtonUnpressed;
        }
    }
}
