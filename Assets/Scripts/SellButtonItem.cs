using UnityEngine;
using UnityEngine.UI; 

public class SellButtonItem : MonoBehaviour
{
    public Text itemName;
    public Image itemImage;
    public Text itemPrice;

    public item item;

    public void BuyItem()
    {
        Inventory inventory = Inventory.instance;

        if (inventory.gemsCount >= item.price)
        {
            inventory.content.Add(item);
            inventory.UpdateInventoryUI();
            inventory.gemsCount -= item.price;
            inventory.updateTextUI();
        }
    }
}