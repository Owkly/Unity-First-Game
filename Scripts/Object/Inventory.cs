using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public int gemsCount;
    public Text gemsCountText;

    public List<item> content = new List<item>();
    public int contentCurrentIndex = 0;

    public Sprite emptyItemImage;

    public static Inventory instance;

    public Image itemImageUI;
    public Text itemNameUI;

    public PlayerEffects playerEffects;

    //fonction lu avant toutes les autres fonctions, même avant start
    //Ca permet d'accéder au scrip inventory n'importe où
    //grâce à static
    private void Awake()
    {
        if (instance != null)
        {
            //Permet de faire en sorte qu'il y ait un seul inventaire
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        UpdateInventoryUI() ;
    }

    public void AddGems(int count)
    {
        gemsCount += count;
        updateTextUI(); 
    }

    public void RemoveGems(int count)
    {
        gemsCount -= count;
        updateTextUI();
    }

    public void updateTextUI()
    {
        gemsCountText.text = gemsCount.ToString();
    }

    public void ConsumeItem()
    {
        if(content.Count == 0)
        {
            return;
        }

        item currentItem = content[contentCurrentIndex];

        //Pour redonner la vie que rend l'objet consommé
        PlayerHealth.instance.GiveHealth(currentItem.hpGiven);
        playerEffects.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);
        MovePlayer1.instance.moveSpeed += currentItem.speedGiven;
        MainDoor.instance.key = currentItem.key;

        //Permet de supprimer l'item que nous venons de consommer 
        content.Remove(currentItem);

        // Permet de remettre au bon index
        GetNextItem();
        UpdateInventoryUI();
    }


    //Ces deux fonctions permettent de faire en sorte de ne sélectionner que les objets
    // que nous avons dans notre inventaire avec le bon index. 
    public void GetNextItem()
    {
        if (content.Count == 0)
        {
            return;
        }
        contentCurrentIndex++;
        if (contentCurrentIndex > content.Count-1)
        {
            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if(content.Count == 0)
        {
            return;
        }

        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if (content.Count > 0)
        {
            itemImageUI.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].name;
        }
        else
        {
            itemImageUI.sprite = emptyItemImage;
            itemNameUI.text = "";
        }
    }
}
