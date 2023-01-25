using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private RectTransform shop;
    [SerializeField] private RectTransform shopcontent;
    [Header("Workers")]
    [SerializeField] private ShopItemUI shopitemUI;

    public void AddShopItem(Worker worker)
    {
        var newItem = Instantiate(shopitemUI, content);
        newItem.UpdateUI(worker);
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
