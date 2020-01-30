using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handler for the main menu
/// </summary>
public class MainMenuFunctionality : MonoBehaviour
{
    [SerializeField]
    GameObject MainMenu = null;
    [SerializeField]
    GameObject SettingsMenu = null;

    public void StartGame() => SceneManager.LoadScene(1);

    public void QuitGame() => Application.Quit();

    public void ShowSettingsMenu()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void ShowMainMenu()
    {
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}
