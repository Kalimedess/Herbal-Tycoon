using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int money = 500;
    public TextMeshProUGUI UIText;
    // tylko tu zaczyna sie gra
    void Start()
    {
        //funkcja od wyswietlania stanu pieniedzy
        UIText.text = money.ToString();
        //funkcja od schowania sklepu / magazynu przy starcie
        //funkcje od przyciskow otwierania i zamykania sklepu / magazynu
        //funkcja foreach od zaladowania obiektow i dodania do magazynu / sklepu
        //funkcja od aktywowania przyciskow w sklepie / magazynie
    }

    // i tylko tu bedzie siê updateowala
    void Update()
    {
        
    }
}
