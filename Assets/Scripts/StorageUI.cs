using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageUI : MonoBehaviour
{
    [SerializeField] private RectTransform storage;
    [SerializeField] private RectTransform storagecontent;
    [Header("Workers")]
    [SerializeField] private ShopWorkerUI shopWorkerUI;

    public void AddWorker(Worker worker)
    {
        var newWorker = Instantiate(shopWorkerUI, content);
        newWorker.UpdateUI(worker);
    }

    public void OpenShop()
    {
        shop.gameObject.SetActive(true);
    }

    public void CloseShop()
    {
        shop.gameObject.SetActive(false);
    }
}
