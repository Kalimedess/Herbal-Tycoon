using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Clickermanager : MonoBehaviour
{
    public static UnityEvent<int, int> OnItemBought = new UnityEvent<int, int>();
    
    
    [Header("General")]
    [SerializeField] private ClickerUI clickerUI;
    [SerializeField] private Button clickerButton;

    [Header("Shop")]
    [SerializeField] private ShopUI shopUI;
    [SerializeField] private Button openButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private List<Worker> workers;

    private int pointsCounter = 0;
    private int pointsPerSecond = 0;

    private void Start()
    {
        clickerUI.UpdateUI(pointsCounter);
        clickerButton.onClick.AddListener(AddPoints);
        shopUI.CloseShop();
        openButton.onClick.AddListener(shopUI.OpenShop);
        closeButton.onClick.AddListener(shopUI.CloseShop);

        foreach(Worker worker in workers)
        {
            shopUI.AddWorker(worker);
        }
        OnItemBought.AddListener(BuyItem);

        InvokeRepeating(nameof(AddPointsPerSecond), 0f, 1f);
    }

    private void AddPointsPerSecond()
    {
        if (pointsPerSecond > 0)
        {
            pointsCounter += pointsPerSecond;
            clickerUI.UpdateUI(pointsCounter);
        }
    }

    private void BuyItem(int price, int power)
    {
        if(price <= pointsCounter)
        {
            pointsPerSecond += power;
            pointsCounter -= price;
            clickerUI.UpdateUI(pointsCounter);
        }
    }

    private void AddPoints()
    {
        pointsCounter += 1;
        clickerUI.UpdateUI(pointsCounter);
    }
}
