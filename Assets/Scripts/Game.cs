using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    public static UnityEvent<int, int> OnPlantBought = new UnityEvent<int, int>();
    
    public int money = 10;
    //public TextMeshProUGUI UIText;
    private Money moneyscript;

    [Header("Shop")]
    [SerializeField] private Shop shop;
    [SerializeField] private Button OpenShopButton;
    [SerializeField] private Button CloseShopButton;
    [SerializeField] private List<Plants> allplants;
    /*
    [Header("Storage")]
    [SerializeField] private Storage storage;
    [SerializeField] private Button OpenStorageButton;
    [SerializeField] private Button CloseStorageButton;
    */

    void Start()
    {
        moneyscript = GetComponent<Money>();
        moneyscript.UpdateMoney(money); //tu wp�ywa na wy�wietlanie

        shop.HideShop();
        OpenShopButton.onClick.AddListener(shop.ShowShop);
        CloseShopButton.onClick.AddListener(shop.HideShop);
        foreach(Plants plant in allplants)
        {
            shop.AddPlant(plant);
        }

        OnPlantBought.addListener(BuyPlant);


        //UIText.text = money.ToString();
        //funkcja od schowania sklepu / magazynu przy starcie
        //funkcje od przyciskow otwierania i zamykania sklepu / magazynu
        //funkcja foreach od zaladowania obiektow i dodania do magazynu / sklepu
        //funkcja od aktywowania przyciskow w sklepie / magazynie
    }

    void Update()
    {
        
    }

    private int BuyPlant(int cena, int ilosc)
    {
        if (cena<=money)
        {
            money = money - cena;
            return ilosc++;
            moneyscript.UpdateMoney(money);
        }
    }
}
