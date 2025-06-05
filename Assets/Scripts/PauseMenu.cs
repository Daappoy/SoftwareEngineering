using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool escapeKeyPressed = false;
    private bool isPaused = false;
    private SceneManager sceneManager;
    public GameObject MainMenuBackground;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !escapeKeyPressed)
        {
            escapeKeyPressed = true;
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape) && escapeKeyPressed)
        {
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
    
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f; // Ensure time scale is reset when returning to the main menu
    }
}
