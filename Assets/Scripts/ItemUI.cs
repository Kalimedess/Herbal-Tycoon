using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI itemamountText;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellButton;
    [SerializeField] private TextMeshProUGUI buypriceText;
    [SerializeField] private TextMeshProUGUI sellpriceText;

    public void UpdateUI(Item item)
    {
        nameText.text = item.itemName;
        itemamountText.text = item.itemamount.ToString();
        buypriceText.text = item.buyprice.ToString();
        sellpriceText.text = item.sellprice.ToString();

        buyButton.onClick.AddListener(delegate { BuyButtonOnClick(item.buyprice, item.itemamount); });
        sellButton.onClick.AddListener(delegate { SellButtonOnClick(item.sellprice, item.itemamount); });
    }

    private void BuyButtonOnClick(int buyprice, int itemamount)
    {
        TycoonManager.OnItemBought?.Invoke(buyprice, itemamount);
    }
    private void SellButtonOnClick(int sellprice, int itemamount)
    {
        TycoonManager.OnItemSold?.Invoke(sellprice, itemamount);
    }
}
