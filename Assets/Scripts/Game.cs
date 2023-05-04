using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    public int money;
    //public TextMeshProUGUI UIText;
    [SerializeField] public Money moneyscript;


    void Start()
    {
        moneyscript.UpdateMoney(money);
    }

    void Update()
    {
        moneyscript.UpdateMoney(money);
    }
}
