using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    [SerializeField] public bool isAttached = false;
    public FoxScript FoxController;
    public CrowScript CrowController;
    public bool isFox = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchPlayer();
        }

        if (isFox == false)
        {
            FoxController.InputEnabled = false;
            CrowController.CrowInputEnabled = true;
        }
        else if (isFox == true)
        {
            FoxController.InputEnabled = true;
            CrowController.CrowInputEnabled = false;
        }
    }
    public void SwitchPlayer()
    {
        if( isFox == true )
        {
            // FoxController.enabled = false;
            // CrowController.enabled = true;
            isFox = false;
        }
        else
        {
            // FoxController.enabled = true;
            // CrowController.enabled = false;
            isFox = true;
        }
    }
}
