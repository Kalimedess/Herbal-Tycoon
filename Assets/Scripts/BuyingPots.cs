using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingPots : MonoBehaviour
{
    public GameObject pot;
    private Game gameManager;
    [SerializeField] private Transform buttonPosition;
    private void Start()
    {
        gameManager = GetComponent<Game>();
    }
    public void buy(int requiredPoints)
    {
        if (gameManager.money > requiredPoints)
        {
            Instantiate(pot,buttonPosition);
            gameManager.money-=requiredPoints;
        }
        else
        {
            return;
        }
    }
}
