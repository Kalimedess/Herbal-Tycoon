using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int money = 10;
    //public TextMeshProUGUI UIText;
    [SerializeField] public Money moneyscript;

    void Start()
    {
        moneyscript.UpdateMoney(money); //tu wp³ywa na wyœwietlanie

        //UIText.text = money.ToString();
        //funkcja od schowania sklepu / magazynu przy starcie
        //funkcje od przyciskow otwierania i zamykania sklepu / magazynu
        //funkcja foreach od zaladowania obiektow i dodania do magazynu / sklepu
        //funkcja od aktywowania przyciskow w sklepie / magazynie
    }

    void Update()
    {
        
    }
}
