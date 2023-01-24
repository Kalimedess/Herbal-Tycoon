using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopWorkerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private Button buyButton;
    [SerializeField] private TextMeshProUGUI priceText;

    public void UpdateUI(Worker worker)
    {
        nameText.text = worker.workerName;
        powerText.text = worker.power.ToString();
        priceText.text = worker.price.ToString();

        buyButton.onClick.AddListener(delegate { BuyButtonOnClick(worker.price, worker.power); });

    }

    private void BuyButtonOnClick(int price, int power)
    {
        Clickermanager.OnItemBought?.Invoke(price, power);
    }
}
