using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject levels;

    private GameObject[] menus;

    private void Start()
    {
        ShowOnly(mainMenu);
    }
    
    private void Awake()
    {
        // Initialize the array of all menu objects
        menus = new GameObject[] { mainMenu, settings, levels };
    }

    // Method to show only one menu and hide all others
    private void ShowOnly(GameObject menuToShow)
    {
        foreach (GameObject menu in menus)
        {
            menu.SetActive(menu == menuToShow);
        }
    }

    // Public methods for specific menus
    public void OpenSettings() => ShowOnly(settings);
    public void OpenMainMenu() => ShowOnly(mainMenu);
    public void OpenLevels() => ShowOnly(levels);
    
    public void Quit()
    {
        Application.Quit();
    }
}