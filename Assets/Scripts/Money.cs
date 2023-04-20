using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI moneytext;

    public void UpdateMoney(uint amount)
    {
        moneytext.text = $"Kasa: {amount}";
    }
}
