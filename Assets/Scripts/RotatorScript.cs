using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class RotatorScript : MonoBehaviour
{
    public PlayerSwitch PS;
    public List<GameObject> RotatorList;
    public float rotationSpeed = 100f;
    public Camera _camera;
    public GameObject Fox;
    public GameObject Crow;
    private bool rotationControl = true;

    //void Update()
    //{
    //    transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    //}

    private void Update()
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

    public void turnControlOff ()
    {
        PS.FoxController.InputEnabled = false;
        PS.CrowController.CrowInputEnabled = false;
        PS.enabled = false;
        StartCoroutine(turnControlOn()); Debug.Log("off");
    }

    public IEnumerator turnControlOn ()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        PS.enabled = true;
        if (PS.isFox)
        {
            PS.FoxController.InputEnabled = true;
        }
        else
        {
            PS.CrowController.CrowInputEnabled = true;
        }
        rotationControl = true;
    }

    public void GameRotateLeft ()
    {
        if (rotationControl)
        {
            rotationControl = false;
            turnControlOff();
            if (transform.eulerAngles.z == 0)
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
            Fox.transform.rotation = Quaternion.Euler(0, 0, 0);
            Crow.transform.rotation = Quaternion.Euler(0, 0, 0);
            _camera.transform.rotation = Quaternion.Euler(0, 0, 0);
             Debug.Log("Left");
        }
    }

    public void GameRotateRight()
    {
        if (rotationControl)
        {
            rotationControl = false;
            turnControlOff();
            if (transform.eulerAngles.z == 0)
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
            Fox.transform.rotation = Quaternion.Euler(0, 0, 0);
            Crow.transform.rotation = Quaternion.Euler(0, 0, 0);
            _camera.transform.rotation = Quaternion.Euler(0, 0, 0);
            
        }
    }
}
