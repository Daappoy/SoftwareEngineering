using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject MainMenuBackground;
    private bool escapeKeyPressed = false;
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        MainMenuBackground.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !escapeKeyPressed){
            escapeKeyPressed = true;
            if(isPaused)
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }

        if(Input.GetKeyUp(KeyCode.Escape)){
            escapeKeyPressed = false;
        }
    }

    public void PauseGame()
    {
        // audioManager.PlaySFX(audioManager.Pause);
        Time.timeScale = 0f;
       // MainMenuPanel.SetActive(true);
        MainMenuBackground.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        // audioManager.PlaySFX(audioManager.ClickOnPause);
        Time.timeScale = 1f;
       // MainMenuPanel.SetActive(false);
        MainMenuBackground.SetActive(false);
        isPaused = false;
    }
}
