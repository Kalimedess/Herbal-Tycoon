using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public List<ItemsInventory> Items = new List<ItemsInventory>();
    public List<ItemsInventory> PlayerItems = new List<ItemsInventory>();

    public static ItemDB Instance;

    void Start()
    {
        Instance = this;
    }

    [System.Serializable]
    public class ItemsInventory
    {
        public string ItemID;
        public string ItemName;
        public string ItemDescription;
        public enum ItemTypes
        {
            Nasiona,Zbiory
        }
        public ItemTypes ItemType;
        public Sprite ItemIcon;
        
    }
}
