using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class RotatorScript : MonoBehaviour
{
    public PlayerSwitch PS;
    //public List<GameObject> RotatorList; //I ended up not using this
    //public float rotationSpeed = 100f;
    public Camera _camera;
    public GameObject Fox;
    public GameObject Crow;
    private bool rotationControl = true;
    public List<GameObject> DoorsHold;
    public int HowManyDoorsHold;
    public List<GameObject> DoorsToggle;
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
        else if (Input.GetKeyDown(KeyCode.V))
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
            if (transform.eulerAngles.z == 0) // check current angle and rotate it, yes this is not optimal, im too lazy
            {
                transform.rotation = Quaternion.Euler(0, 0, 90); 
            }
            else if (transform.eulerAngles.z == 90)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (transform.eulerAngles.z == 180)
            {
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            Fox.transform.rotation = Quaternion.Euler(0, 0, 0); // due to this 3 need to be foldered to join the rotation, they need to be rotated back to 0
            Crow.transform.rotation = Quaternion.Euler(0, 0, 0);
            _camera.transform.rotation = Quaternion.Euler(0, 0, 0);
            updatethedoorcoord();
        }
    }

    private void GameRotateRight() // method for rotating counter clockwise
    {
        if (rotationControl) // check if input for rotation is allowed
        {
            rotationControl = false; // stop spam
            turnControlOff();
            if (transform.eulerAngles.z == 0) // check current angle and rotate it, yes this is not optimal, im too lazy
            {
                transform.rotation = Quaternion.Euler(0, 0, 270); 
            }
            else if (transform.eulerAngles.z == 270)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (transform.eulerAngles.z == 180)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            Fox.transform.rotation = Quaternion.Euler(0, 0, 0); // due to this 3 need to be foldered to join the rotation, they need to be rotated back to 0
            Crow.transform.rotation = Quaternion.Euler(0, 0, 0);
            _camera.transform.rotation = Quaternion.Euler(0, 0, 0);
            updatethedoorcoord();
        }
    }

    private void updatethedoorcoord ()
    {
        for (int i = 0; i < HowManyDoorsHold; i++)
        {
            if (DoorsHold[i].GetComponent<DoorHold>().isOpen && DoorsHold[i].GetComponent<DoorHold>().isSideWay)
            {
                if (transform.eulerAngles.z == 0) // check current angle and rotate it, yes this is not optimal, im too lazy
                {
                    DoorsHold[i].GetComponent<DoorHold>().InitialPos = new Vector3(DoorsHold[i].transform.position.x + 3, DoorsHold[i].transform.position.y, DoorsHold[i].transform.position.z);
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(-3, 0, 0);
                }
                else if (transform.eulerAngles.z == 90)
                {
                    DoorsHold[i].GetComponent<DoorHold>().InitialPos = new Vector3(DoorsHold[i].transform.position.x, DoorsHold[i].transform.position.y + 3, DoorsHold[i].transform.position.z);
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(0, -3, 0);
                }
                else if (transform.eulerAngles.z == 180)
                {
                    DoorsHold[i].GetComponent<DoorHold>().InitialPos = new Vector3(DoorsHold[i].transform.position.x - 3, DoorsHold[i].transform.position.y, DoorsHold[i].transform.position.z);
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(3, 0, 0);
                }
                else
                {
                    DoorsHold[i].GetComponent<DoorHold>().InitialPos = new Vector3(DoorsHold[i].transform.position.x, DoorsHold[i].transform.position.y - 3, DoorsHold[i].transform.position.z);
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(0, 3, 0);
                }
            }
            else if (!DoorsHold[i].GetComponent<DoorHold>().isOpen && DoorsHold[i].GetComponent<DoorHold>().isSideWay)
            {
                DoorsHold[i].GetComponent<DoorHold>().InitialPos = DoorsHold[i].transform.position;
                if (transform.eulerAngles.z == 0) // check current angle and rotate it, yes this is not optimal, im too lazy
                {
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(-3, 0, 0);
                }
                else if (transform.eulerAngles.z == 90)
                {
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(0, -3, 0);
                }
                else if (transform.eulerAngles.z == 180)
                {
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(3, 0, 0);
                }
                else
                {
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(0, 3, 0);
                }
            }
            else if (DoorsHold[i].GetComponent<DoorHold>().isOpen && !DoorsHold[i].GetComponent<DoorHold>().isSideWay)
            {
                if (transform.eulerAngles.z == 0) // check current angle and rotate it, yes this is not optimal, im too lazy
                {
                    DoorsHold[i].GetComponent<DoorHold>().InitialPos = new Vector3(DoorsHold[i].transform.position.x, DoorsHold[i].transform.position.y - 3, DoorsHold[i].transform.position.z);
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(0, 3, 0);
                }
                else if (transform.eulerAngles.z == 90)
                {
                    DoorsHold[i].GetComponent<DoorHold>().InitialPos = new Vector3(DoorsHold[i].transform.position.x + 3, DoorsHold[i].transform.position.y, DoorsHold[i].transform.position.z);
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(-3, 0, 0);
                }
                else if (transform.eulerAngles.z == 180)
                {
                    DoorsHold[i].GetComponent<DoorHold>().InitialPos = new Vector3(DoorsHold[i].transform.position.x, DoorsHold[i].transform.position.y + 3, DoorsHold[i].transform.position.z);
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(0, -3, 0);
                }
                else
                {
                    DoorsHold[i].GetComponent<DoorHold>().InitialPos = new Vector3(DoorsHold[i].transform.position.x - 3, DoorsHold[i].transform.position.y, DoorsHold[i].transform.position.z);
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(3, 0, 0);
                }
            }
            else
            {
                DoorsHold[i].GetComponent<DoorHold>().InitialPos = DoorsHold[i].transform.position;
                if (transform.eulerAngles.z == 0) // check current angle and rotate it, yes this is not optimal, im too lazy
                {
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(0, 3, 0);
                }
                else if (transform.eulerAngles.z == 90)
                {
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(-3, 0, 0);
                }
                else if (transform.eulerAngles.z == 180)
                {
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(0, -3, 0);
                }
                else
                {
                    DoorsHold[i].GetComponent<DoorHold>().offsetPosHold = new Vector3(3, 0, 0);
                }
            }
        }
        for (int i = 0; i < HowManyDoorsToggle; i++)
        {
            if (DoorsToggle[i].GetComponent<DoorToggle>().isOpen && DoorsToggle[i].GetComponent<DoorToggle>().isSideWay)
            {
                if (transform.eulerAngles.z == 0) // check current angle and rotate it, yes this is not optimal, im too lazy
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().initialPos = new Vector3(DoorsToggle[i].transform.position.x + 3, DoorsToggle[i].transform.position.y, DoorsToggle[i].transform.position.z);
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(-3, 0, 0);
                }
                else if (transform.eulerAngles.z == 90)
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().initialPos = new Vector3(DoorsToggle[i].transform.position.x, DoorsToggle[i].transform.position.y + 3, DoorsToggle[i].transform.position.z);
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(0, -3, 0);
                }
                else if (transform.eulerAngles.z == 180)
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().initialPos = new Vector3(DoorsToggle[i].transform.position.x - 3, DoorsToggle[i].transform.position.y, DoorsToggle[i].transform.position.z);
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(3, 0, 0);
                }
                else
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().initialPos = new Vector3(DoorsToggle[i].transform.position.x, DoorsToggle[i].transform.position.y - 3, DoorsToggle[i].transform.position.z);
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(0, 3, 0);
                }
            }
            else if (!DoorsToggle[i].GetComponent<DoorToggle>().isOpen && DoorsToggle[i].GetComponent<DoorToggle>().isSideWay)
            {
                DoorsToggle[i].GetComponent<DoorToggle>().initialPos = DoorsToggle[i].transform.position;
                if (transform.eulerAngles.z == 0) // check current angle and rotate it, yes this is not optimal, im too lazy
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(3, 0, 0);
                }
                else if (transform.eulerAngles.z == 90)
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(0, -3, 0);
                }
                else if (transform.eulerAngles.z == 180)
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(3, 0, 0);
                }
                else
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(0, 3, 0);
                }
            }
            else if (DoorsToggle[i].GetComponent<DoorToggle>().isOpen && DoorsToggle[i].GetComponent<DoorToggle>().isSideWay)
            {
                if (transform.eulerAngles.z == 0) // check current angle and rotate it, yes this is not optimal, im too lazy
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().initialPos = new Vector3(DoorsToggle[i].transform.position.x, DoorsToggle[i].transform.position.y - 3, DoorsToggle[i].transform.position.z);
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(0, 3, 0);
                }
                else if (transform.eulerAngles.z == 90)
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().initialPos = new Vector3(DoorsToggle[i].transform.position.x + 3, DoorsToggle[i].transform.position.y, DoorsToggle[i].transform.position.z);
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(-3, 0, 0);
                }
                else if (transform.eulerAngles.z == 180)
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().initialPos = new Vector3(DoorsToggle[i].transform.position.x, DoorsToggle[i].transform.position.y + 3, DoorsToggle[i].transform.position.z);
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(0, -3, 0);
                }
                else
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().initialPos = new Vector3(DoorsToggle[i].transform.position.x - 3, DoorsToggle[i].transform.position.y, DoorsToggle[i].transform.position.z);
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(3, 0, 0);
                }
            }
            else 
            {
                DoorsToggle[i].GetComponent<DoorToggle>().initialPos = DoorsToggle[i].transform.position;
                if (transform.eulerAngles.z == 0) // check current angle and rotate it, yes this is not optimal, im too lazy
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(0, 3, 0);
                }
                else if (transform.eulerAngles.z == 90)
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(-3, 0, 0);
                }
                else if (transform.eulerAngles.z == 180)
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(0, -3, 0);
                }
                else
                {
                    DoorsToggle[i].GetComponent<DoorToggle>().offsetPos = new Vector3(3, 0, 0);
                }
            }
        }
    }
}
