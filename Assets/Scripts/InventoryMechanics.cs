using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMechanics : MonoBehaviour
{
    [SerializeField] RectTransform Inventory;
    [SerializeField] Button openInventory;
    [SerializeField] Button closeInventory;
    bool ActiveInventory = false;
    void Start()
    {
        Inventory.gameObject.SetActive(false);
        openInventory.onClick.AddListener(OpenInventory);
        closeInventory.onClick.AddListener(CloseInventory);
        AddItemToInventory(2);
        
    }
    public void OpenInventory()
    {
        if (!ActiveInventory) 
        { 
            Inventory.gameObject.SetActive(true);
            ActiveInventory = true;
        }
        else
        {
            Inventory.gameObject.SetActive(false);
            ActiveInventory = false;
        }
            
    }
    public void CloseInventory()
    {
        Inventory.gameObject.SetActive(false);
    }
    public void AddItemToInventory(int numberofitem)
    {
        ItemDB.Instance.PlayerItems.Add(ItemDB.Instance.Items[numberofitem]);
    }
}
