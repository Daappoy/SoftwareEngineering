using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxAnimatorScript : MonoBehaviour
{   
    public PlayerSwitch playerSwitchScript;
    public FoxScript foxScript;
    [Header("Animator")]
    [SerializeField] public Animator FoxAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FoxAnimator.SetFloat("speed", Mathf.Abs(foxScript.Horizontal));
        FoxAnimator.SetBool("isFox", playerSwitchScript.isFox);
    }
}
