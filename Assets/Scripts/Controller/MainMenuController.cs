using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelMenu;
    public GameObject settings;

    private void Start()
    {
        InitOpening();
    }

    private void InitOpening()
    {
        mainMenu.SetActive(true);
    }

    public void BackToMainMenu()
    {
        levelMenu.SetActive(false);
        settings.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OpenLevels()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }
}
