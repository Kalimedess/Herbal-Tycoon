using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TycoonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;

    public void UpdateUI(int amount)
    {
        counterText.text = $"Kasa: {amount}";
    }
}