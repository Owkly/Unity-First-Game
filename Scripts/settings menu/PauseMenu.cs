using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //c'est ce qui va nous permettre de savoir si le jeu est en pause ou non 
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject settingsWindow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
             if (GameIsPaused)
            {
                Resume();
            }
             else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        //permet d'arrêter les mouvements du joueur
        MovePlayer1.instance.enabled = false;

        //activer notre menu pause /afficher
        pauseMenuUI.SetActive(true);

        //arrêter le temps
        //ça va permettre de freeze le temps
        Time.timeScale = 0;

        //changer le status du jeu
        GameIsPaused = true;
    }

    public void Resume()
    {
        //permet de réactiver les mouvements du joueur
        MovePlayer1.instance.enabled = true;
        pauseMenuUI.SetActive(false);

        //arrêter le temps
        //ça va permettre d'activer le temps
        Time.timeScale = 1;

        //changer le status du jeu
        GameIsPaused = false;
    }

    public void OpenSettingsWindow()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("main_menu");
    }
}
