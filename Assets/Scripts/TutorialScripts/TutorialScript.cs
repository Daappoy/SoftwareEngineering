using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [Header("Triggers")]
    public BoxCollider2D FoxMovementTrigger;
    public BoxCollider2D FoxPushTrigger;
    public BoxCollider2D FoxJumpTrigger;
    public BoxCollider2D FoxPipeInteractTrigger;
    public BoxCollider2D CrowMovementTrigger;
    public BoxCollider2D CrowLiftBoxTrigger;
    public BoxCollider2D ExitDoorTrigger;

    [Header("Tutorial Panels")]
    public GameObject FoxMovementTutorial;
    public GameObject FoxPushTutorial;
    public GameObject FoxJumpTutorial;
    public GameObject FoxPipeInteractTutorial;
    public GameObject CrowMovementTutorial;
    public GameObject CrowLiftBoxTutorial;
    public GameObject ExitDoorTutorial; // Reference to the exit door tutorial GameObject

    // Start is called before the first frame update
    void Start()
    {
        // Ensure all tutorial GameObjects are initially inactive
        if (FoxMovementTutorial != null) FoxMovementTutorial.SetActive(false);
        if (FoxPushTutorial != null) FoxPushTutorial.SetActive(false);
        if (FoxJumpTutorial != null) FoxJumpTutorial.SetActive(false);
        if (FoxPipeInteractTutorial != null) FoxPipeInteractTutorial.SetActive(false);
        if (CrowMovementTutorial != null) CrowMovementTutorial.SetActive(false);
        if (CrowLiftBoxTutorial != null) CrowLiftBoxTutorial.SetActive(false);
        if (ExitDoorTutorial != null) ExitDoorTutorial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //fox movement tutorial
        if (gameObject == FoxMovementTrigger && other.CompareTag("Player"))
        {
            FoxMovementTutorial.SetActive(true); // Show the movement tutorial when the player enters the trigger
        }
        //fox jump tutorial
        if (gameObject == FoxJumpTrigger && other.CompareTag("Player"))
        {
            FoxJumpTutorial.SetActive(true); // Show the jump tutorial when the player enters the trigger
        }
        //fox push tutorial
        if (gameObject == FoxPushTrigger && other.CompareTag("Player"))
        {
            FoxPushTutorial.SetActive(true); // Show the push tutorial when the player enters the trigger
        }
        //fox pipe interact tutorial
        if (gameObject == FoxPipeInteractTrigger && other.CompareTag("Player"))
        {
            FoxPipeInteractTutorial.SetActive(true); // Show the pipe interact tutorial when the player enters the trigger
        }
        //crow movement tutorial
        if (gameObject == CrowMovementTrigger && other.CompareTag("Player"))
        {
            CrowMovementTutorial.SetActive(true); // Show the crow movement tutorial when the player enters the trigger
        }
        //crow lift box tutorial
        if (gameObject == CrowLiftBoxTrigger && other.CompareTag("Player"))
        {
            CrowLiftBoxTutorial.SetActive(true); // Show the crow lift box tutorial when the player enters the trigger
        }
        //exit door tutorial
        if (gameObject == ExitDoorTrigger && other.CompareTag("Player"))
        {
            ExitDoorTutorial.SetActive(true); // Show the exit door tutorial when the player enters the trigger
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //fox movement tutorial
        if (gameObject == FoxMovementTrigger && other.CompareTag("Player"))
        {
            FoxMovementTutorial.SetActive(false); // Hide the movement tutorial when the player exits the trigger
        }
        //fox jump tutorial
        if (gameObject == FoxJumpTrigger && other.CompareTag("Player"))
        {
            FoxJumpTutorial.SetActive(false); // Hide the jump tutorial when the player exits the trigger
        }
        //fox push tutorial
        if (gameObject == FoxPushTrigger && other.CompareTag("Player"))
        {
            FoxPushTutorial.SetActive(false); // Hide the push tutorial when the player exits the trigger
        }
        //fox pipe interact tutorial
        if (gameObject == FoxPipeInteractTrigger && other.CompareTag("Player"))
        {
            FoxPipeInteractTutorial.SetActive(false); // Hide the pipe interact tutorial when the player exits the trigger
        }
        //crow movement tutorial
        if (gameObject == CrowMovementTrigger && other.CompareTag("Player"))
        {
            CrowMovementTutorial.SetActive(false); // Hide the crow movement tutorial when the player exits the trigger
        }
        //crow lift box tutorial
        if (gameObject == CrowLiftBoxTrigger && other.CompareTag("Player"))
        {
            CrowLiftBoxTutorial.SetActive(false); // Hide the crow lift box tutorial when the player exits the trigger
        }
        //exit door tutorial
        if (gameObject == ExitDoorTrigger && other.CompareTag("Player"))
        {
            ExitDoorTutorial.SetActive(false); // Hide the exit door tutorial when the player exits the trigger
        }
    }
}
