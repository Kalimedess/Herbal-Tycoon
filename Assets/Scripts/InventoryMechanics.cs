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
        UpdateInventorySlots();
    }

    void UpdateInventorySlots()
    {
        for(int i = 0; i < Inventory.transform.childCount; i++)
        {
            if (i < ItemDB.Instance.PlayerItems.Count)
            {
                Inventory.transform.GetChild(i).Find("Icon").gameObject.SetActive(true);
                Inventory.transform.GetChild(i).Find("Icon").GetComponent<Image>().sprite=ItemDB.Instance.PlayerItems[i].ItemIcon;
            }
            else
            {
                Inventory.transform.GetChild(i).Find("Icon").gameObject.SetActive(false);
                Inventory.transform.GetChild(i).Find("Icon").GetComponent<Image>().sprite = null;

            }
        }
    }
}
