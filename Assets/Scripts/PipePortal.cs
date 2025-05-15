using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePortal : MonoBehaviour
{
    public GameObject PortalLinked; //Target location

    private void OnTriggerEnter2D(Collider2D other) //OnEnter move
    {
        if (other.tag == "Player")
        {
            other.transform.position = PortalLinked.transform.position; //literally just move
        }
    }
}
