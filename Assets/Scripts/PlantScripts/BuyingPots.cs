using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyingPots : MonoBehaviour
{
    public GameObject pot;
    private Game gameManager;
    public GameObject buyButton;

    private void Start()
    {
        gameManager = GetComponent<Game>();

    }
    public void BuyPot(int price)
    {
        if (!buyButton.IsUnityNull() && !pot.IsUnityNull())
        {
            if (gameManager.money >= price)
            {
                Instantiate(pot, (Vector2)buyButton.transform.position, Quaternion.identity);
                gameManager.money -= price;
                Destroy(buyButton);
            }
        }
    }
}
