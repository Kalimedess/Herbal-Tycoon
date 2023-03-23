using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private RectTransform shop;
    [SerializeField] private RectTransform shopcontent;
    [SerializeField] private PlantInShop plantsinshop;

    public void ShowShop()
    {
        shop.gameObject.SetActive(true);
    }
    public void HideShop()
    {
        shop.gameObject.SetActive(false);
    }
    public void AddPlant(Plants plant)
    {
        var newPlant = Instantiate(plantsinshop, shopcontent);
        newPlant.UpdateShopPlants(plant);
    }
}
