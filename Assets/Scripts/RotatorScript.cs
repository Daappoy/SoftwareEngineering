using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class RotatorScript : MonoBehaviour
{
    public Transform RotatorTransform;
    public PlayerSwitch PS;
    //public List<GameObject> RotatorList; //I ended up not using this
    //public float rotationSpeed = 100f;
    public Camera _camera;
    public GameObject Fox;
    public GameObject Crow;
    private bool rotationControl = true;
    public List<GameObject> DoorsHold;
    public int HowManyDoorsHold;
    public List<GameObject> Boxes;
    public int HowManyDoorsToggle;

    //void Update()
    //{
    //    transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    //}

    private void Update() // get input from C or V, if you want to change this, go ahead, but do tell me
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameRotateLeft();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            GameRotateRight();
        }
        
    }

    private void turnControlOff () // method to turn off all inputs from the player to stop spams
    {
        PS.FoxController.InputEnabled = false; // PS is PlayerSwitch
        PS.CrowController.CrowInputEnabled = false;
        PS.enabled = false;
        StartCoroutine(turnControlOn()); Debug.Log("off"); // this calls to turn it back on automaticlly after a time gap
    }

    private IEnumerator turnControlOn () // method to turn on all input back, theorethicaly, no deep test has been done
    {
        yield return new WaitForSecondsRealtime(2.0f); // I set time as a gap before next input, the float here is how many second the time of the gap
        PS.enabled = true;
        if (PS.isFox) // this checks which on is the current active charc
        {
            PS.FoxController.InputEnabled = true;
        }
        else
        {
            PS.CrowController.CrowInputEnabled = true;
        }
        rotationControl = true; // not sure if I should put this after or before the time gap
    }

    private void GameRotateLeft () // method for rotating clockwise
    {
        if (rotationControl) // check if input for rotation is allowed
        {
            rotationControl = false; // stop spam
            turnControlOff();
            if (RotatorTransform.eulerAngles.z == 0) // check current angle and rotate it, yes this is not optimal, im too lazy
            {
                RotatorTransform.rotation = Quaternion.Euler(0, 0, 90); 
            }
            else if (RotatorTransform.eulerAngles.z == 90)
            {
                RotatorTransform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (RotatorTransform.eulerAngles.z == 180)
            {
                RotatorTransform.rotation = Quaternion.Euler(0, 0, 270);
            }
            else
            {
                RotatorTransform.rotation = Quaternion.Euler(0, 0, 0);
            }
            Fox.transform.rotation = Quaternion.Euler(0, 0, 0); // due to this 3 need to be foldered to join the rotation, they need to be rotated back to 0
            Crow.transform.rotation = Quaternion.Euler(0, 0, 0);
            _camera.transform.rotation = Quaternion.Euler(0, 0, 0);
            // updatethedoorcoord();
        }
    }

    private void GameRotateRight() // method for rotating counter clockwise
    {
        if (rotationControl) // check if input for rotation is allowed
        {
            rotationControl = false; // stop spam
            turnControlOff();
            if (RotatorTransform.eulerAngles.z == 0) // check current angle and rotate it, yes this is not optimal, im too lazy
            {
                RotatorTransform.rotation = Quaternion.Euler(0, 0, 270); 
            }
            else if (RotatorTransform.eulerAngles.z == 270)
            {
                RotatorTransform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (RotatorTransform.eulerAngles.z == 180)
            {
                RotatorTransform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                RotatorTransform.rotation = Quaternion.Euler(0, 0, 0);
            }
            Fox.transform.rotation = Quaternion.Euler(0, 0, 0); // due to this 3 need to be foldered to join the rotation, they need to be rotated back to 0
            Crow.transform.rotation = Quaternion.Euler(0, 0, 0);
            _camera.transform.rotation = Quaternion.Euler(0, 0, 0);
            // updatethedoorcoord();
        }
    }
}
