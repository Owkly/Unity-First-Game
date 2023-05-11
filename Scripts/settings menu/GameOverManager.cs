using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    //Pour afficher et désafficher le menu
    public GameObject gameOverUI;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance de GameOverManager dans la scène");
            return;
        }

        instance = this;
    }

    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }

    //Recommencer le niveau
    public void RetryButton()
    {
        //Reset le nombre de pièce ramasser durant la scène
        Inventory.instance.RemoveGems(CurrentSceneManager.instance.GemsPickedUpInThisCount);

        //Recharge la scène
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //Replace le joueur au Spawn
        //Réactiver les mouvements du joueur et qu'on lui redonne de la vie
        PlayerHealth.instance.Respawn();

        if (PlayerHealth.instance.isInvincible == true)
        {
            PlayerHealth.instance.isInvincible = false;
        }
        

        gameOverUI.SetActive(false);
    }

    public void MainMenuButton()
    {
        //Retour au menu principal
        SceneManager.LoadScene("main_menu");
    }

    public void QuitButton()
    {
        //Fermer le jeu
        Application.Quit();
    }
}
