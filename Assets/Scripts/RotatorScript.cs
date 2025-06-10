using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorScript : MonoBehaviour
{
    public PlayerSwitch PS;
    public List<GameObject> RotatorList;
    public float rotationSpeed = 100f;
    public Camera _camera;

    //void Update()
    //{
    //    transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    //}

    public void turnControlOff ()
    {
        PS.FoxController.InputEnabled = false;
        PS.CrowController.CrowInputEnabled = false;
        PS.enabled = false;
        StartCoroutine(turnControlOn());
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
    }

    public void GameRotateLeft ()
    {
        turnControlOff();
        _camera.transform.rotation = Quaternion.Euler(0, 0, 90);
    }
}
