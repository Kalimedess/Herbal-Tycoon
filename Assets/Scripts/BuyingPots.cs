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

    private bool isButtonNull(GameObject Button) => Button.IsUnityNull();
    private bool isPotNull(GameObject pot) => pot.IsUnityNull();
    private void Start()
    {
        this.enabled = false;
        gameManager = GetComponent<Game>();
    }
    private void OnEnable()
    {
        if (!isButtonNull(buyButton))
        {
            if (!isPotNull(pot))
            {
                if (gameManager.money >= 500)
                {
                    Instantiate(pot, buyButton.transform);
                    gameManager.money -= 500;
                    gameManager.updateMoney();
                    Destroy(buyButton);
                }
                else
                {
                    this.enabled = false;
                    return;
                }
            }
        }
    }
}
