using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TycoonManager : MonoBehaviour
{
    public static UnityEvent<int, int> OnItemBought = new UnityEvent<int, int>();
    public static UnityEvent<int, int> OnItemSold = new UnityEvent<int, int>();
    
    
    [Header("General")]
    [SerializeField] private TycoonUI tycoonUI;
    [SerializeField] private Button tycoonButton;

    [Header("Shop")]
    [SerializeField] private ShopUI shopUI;
    [SerializeField] private Button shopopenButton;
    [SerializeField] private Button shopcloseButton;
    [SerializeField] private List<Item> items;
    
    [Header("Storage")]
    [SerializeField] private StorageUI storageUI;
    [SerializeField] private Button storageopenButton;
    [SerializeField] private Button storagecloseButton;

    private int money = 100;

    private void Start()
    {
        tycoonUI.UpdateUI(money);
        tycoonButton.onClick.AddListener(AddPoints);

        shopUI.CloseShop();
        storageUI.CloseStorage();

        shopopenButton.onClick.AddListener(shopUI.OpenShop);
        shopcloseButton.onClick.AddListener(shopUI.CloseShop);
        storageopenButton.onClick.AddListener(storageUI.OpenStorage);
        storagecloseButton.onClick.AddListener(storageUI.CloseStorage);

        foreach(Item item in items)
        {
            shopUI.AddShopItem(item);
            storageUI.AddStorageItem(item);
        }
        OnItemBought.AddListener(BuyItem);
        OnItemSold.AddListener(SellItem);
    }

    private void BuyItem(int price, int itemamount)
    {
        if(price <= money)
        {
            itemamount+=1;
            money -= price;
            tycoonUI.UpdateUI(money);
        }
    }
    private void SellItem(int price, int itemamount)
    {
        if(itemamount>=1)
        {
            itemamount-=1;
            money += price;
            tycoonUI.UpdateUI(money);
        }
    }

    private void AddPoints()
    {
        money += 10;
        tycoonUI.UpdateUI(money);
    }
}
