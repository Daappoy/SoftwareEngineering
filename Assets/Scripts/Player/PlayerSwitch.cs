using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public FoxScript FoxController;
    public CrowScript CrowController;
    public bool isFox = true;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SwitchPlayer();
        }
    }
    public void SwitchPlayer()
    {
        if(isFox == true )
        {
            FoxController.enabled = false;
            CrowController.enabled = true;
            isFox = false;
        }
        else
        {
            FoxController.enabled = true;
            CrowController.enabled = false;
            isFox = true;
        }
    }
}
