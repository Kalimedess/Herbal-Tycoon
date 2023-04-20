using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyingPots : MonoBehaviour
{
    [SerializeField] private GameObject pot;
    private Game gameManager;
    [SerializeField] private GameObject[] buyButton;

    private void Start()
    {
        gameManager = GetComponent<Game>();

    }
    public void BuyPot(uint price)
    {
        if (!buyButton.IsUnityNull() && !pot.IsUnityNull())
        {
            if (gameManager.money >= price)
            {
                Instantiate(pot, (Vector2)buyButton[0].transform.position, Quaternion.identity);
                gameManager.money -= price;
                Destroy(buyButton[0]);
            }
        }
    }
}
