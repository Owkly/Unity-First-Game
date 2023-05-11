using System.Linq;
using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance de LoadAndSaveData dans la scène");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Permet de prendre la valeur des gems dans la base de donnée, ou 0 sinon
        Inventory.instance.gemsCount = PlayerPrefs.GetInt("gemsCount", 0);
        Inventory.instance.updateTextUI();

        //int currentHealth = PlayerPrefs.GetInt("playerHealth", PlayerHealth.instance.currentHealth);
        //PlayerHealth.instance.currentHealth = currentHealth;
        //PlayerHealth.instance.healthbar.SetHealth(currentHealth);

        string[] itemsSaved = PlayerPrefs.GetString("invertoryItems", "").Split(",");

        for (int i = 0; i < itemsSaved.Length; i++)
        {
            if (itemsSaved[i] != "")
            {   
                int id = int.Parse(itemsSaved[i]);
                item currentItem = ItemsDatabase.instance.allItems.Single(x => x.id == id);
                Inventory.instance.content.Add(currentItem);
            }
        }
    }

    public void SaveData()
    {
        // Permet d'enregistrer le nombre de pièce récupérére à la fin du niveau lors du passage du niveau suivant
        // Permet de récupérer la vie du joueur
        // Permet de récupérer le niveau débloqué
        PlayerPrefs.SetInt("gemsCount", Inventory.instance.gemsCount);
        //PlayerPrefs.SetInt("playerHealth", PlayerHealth.instance.currentHealth);

        if (CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }

        // sauvegarde
        string itemsInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("invertoryItems", itemsInInventory);

        // chargement
    }
}
