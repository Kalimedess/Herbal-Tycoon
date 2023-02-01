using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private RectTransform shop;
    [SerializeField] private RectTransform shopcontent;
    [Header("Items")]
    [SerializeField] private ItemUI itemUI;

    public void AddShopItem(Item item)
    {
        var newItem = Instantiate(itemUI, shopcontent);
        newItem.UpdateUI(item);
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
