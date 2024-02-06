using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;

    public GameObject settingsWindow;
  
    //Permet de load la scène que on lui met en paramètre 
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad); 
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void LoadCreditScene()
    {
        SceneManager.LoadScene("credit");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
