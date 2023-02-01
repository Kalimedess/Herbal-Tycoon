using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageUI : MonoBehaviour
{
    [SerializeField] private RectTransform storage;
    [SerializeField] private RectTransform storagecontent;
    [Header("Items")]
    [SerializeField] private ItemUI itemUI;

    public void AddStorageItem(Item item)
    {
        var newItem = Instantiate(itemUI, storagecontent);
        newItem.UpdateUI(item);
    }

    public void OpenStorage()
    {
        storage.gameObject.SetActive(true);
    }

    public void CloseStorage()
    {
        storage.gameObject.SetActive(false);
    }
}
