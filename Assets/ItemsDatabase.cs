using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDatabase : MonoBehaviour
{
    public item[] allItems;

    public static ItemsDatabase instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il n'y a plus d'instance de ItemsDatabase dans la scène");
            return;
        }
        instance = this;
    }
}
