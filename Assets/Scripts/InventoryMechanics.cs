using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMechanics : MonoBehaviour
{
    [SerializeField] RectTransform Inventory;
    [SerializeField] Button openInventory;
    [SerializeField] Button closeInventory;
    public GameObject inventorySlotPrefab;
    public List<RectTransform> inventoryPanel;
    bool ActiveInventory = false;
    void Start()
    {
        //Inventory.gameObject.SetActive(false);
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
        for (int i = 0; i < inventoryPanel.Count; i++)
        {

            if (inventoryPanel[i].childCount <= 0)
            {
                GameObject newSlot = Instantiate(inventorySlotPrefab, inventoryPanel[i]);
                RectTransform slotRectTransform = newSlot.GetComponent<RectTransform>();
                newSlot.SetActive(true);
            }
        }
    }
}
