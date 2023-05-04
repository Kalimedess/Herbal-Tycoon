using Unity.VisualScripting;
using UnityEngine;

public class BuyingPots : MonoBehaviour
{
    [SerializeField] private GameObject pot;
    [SerializeField] private Game gameManager;
    [SerializeField] private GameObject buyButton;
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
