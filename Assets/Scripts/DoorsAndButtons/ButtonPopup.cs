using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPopup : MonoBehaviour
{
    [SerializeField] public int buttonPopupID;
    public DoorPopup doorPopup;
    [SerializeField]
    public Sprite LeverOn;
    [SerializeField]
    public Sprite LeverOff;
    // Start is called before the first frame update
    void Start()
    {  
       DoorPopup[] doors = FindObjectsOfType<DoorPopup>();
        foreach (DoorPopup d in doors)
        {
            if (d.doorPopupID == buttonPopupID)
            {
                doorPopup = d;
                break;
            }
        } 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Crow"))
        {
            doorPopup.ToggleDoor(); //buka pintu
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (doorPopup.doorPopupID == buttonPopupID && doorPopup.Appear == true)
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
