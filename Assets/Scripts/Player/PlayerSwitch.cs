using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    [SerializeField] public bool isAttached = false;
    public FoxScript FoxController;
    public CrowScript CrowController;
    public bool isFox = true;
    public AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

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
            if (audioManager != null)
            {
                audioManager.PlaySFX(audioManager.CrowSound);
            }
        }
        else if (isFox == true)
        {
            FoxController.InputEnabled = true;
            CrowController.CrowInputEnabled = false;
            if (audioManager != null)
            {
                audioManager.PlaySFX(audioManager.FoxSound);
            }
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
