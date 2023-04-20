using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInventory : MonoBehaviour
{
    [SerializeField] RectTransform Inventory;
    [SerializeField] Button openInventory;
    [SerializeField] Button closeInventory;
    void Start()
    {
        Inventory.gameObject.SetActive(false);
        openInventory.onClick.AddListener(OpenInventory);
        closeInventory.onClick.AddListener(CloseInventory);
    }
    public void OpenInventory()
    {
        Inventory.gameObject.SetActive(true);
    }
    public void CloseInventory()
    {
        Inventory.gameObject.SetActive(false);
    }

}
