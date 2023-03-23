using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantInShop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI shopplantName;
    [SerializeField] private TextMeshProUGUI shopseedquantity;
    [SerializeField] private TextMeshProUGUI shopbuyprice;
    [SerializeField] private Sprite seedsprite;
    [SerializeField] private Button BuyButton;

    public void UpdateShopPlants(Plants plant)
    {
        shopplantName.text = plant.plantName;
        shopseedquantity.text = plant.seedquantity.ToString();
        shopbuyprice.text = plant.buyPrice.ToString();

        BuyButton.onClick.AddListener(delegate { BuyButtonOnClick(plant.buyPrice, plant.seedquantity); });
    }

    private void BuyButtonOnClick(int price, int squantity)
    {
        Game.OnPlantBought?.Invoke(price, squantity);
    }
}
