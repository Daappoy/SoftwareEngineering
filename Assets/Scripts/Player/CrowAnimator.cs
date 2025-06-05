using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowAnimator : MonoBehaviour
{
    [SerializeField]
    public CrowScript crowScript;
    [SerializeField]
    private Animator crowAnimator;
    [SerializeField]
    private AttachController attachController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        crowAnimator.SetFloat("YVelocity", crowScript.CrowRb.velocity.y);
        crowAnimator.SetBool("isFlying", crowScript.isFlying);

        if( attachController.isAttached == true )
        {
            crowAnimator.SetBool("isAttached", true);
        }
        else if (attachController.isAttached == false) 
        {
            crowAnimator.SetBool("isAttached", false);
        }
    }
}
