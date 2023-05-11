using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Inventory/Item")]
public class item : ScriptableObject
{
    public int id;
    public string name;
    public string description;
    public int price;
    public Sprite image;
    public int hpGiven;
    public int speedGiven;
    public float speedDuration;
    public bool key;
}
