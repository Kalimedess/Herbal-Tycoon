using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingPots : MonoBehaviour
{
    private Points checkPoints;
    public NoMoney nomon;
    public GameObject pot;
    private void Start()
    {
        checkPoints = GetComponent<Points>();
        
    }
    public void buy(int requiredPoints)
    {
        switch (requiredPoints) {
            case 100:
                Instantiate(pot, new Vector2(-4.723616f, 0.9894762f), Quaternion.identity);
                checkPoints.points -= 100;
            break;
            case 300:
                checkPoints.points -= 300;
                Instantiate(pot, new Vector2(-3.251468f, 0.9894762f), Quaternion.identity);
                Destroy(gameObject);
                break;
            case 1000:
                checkPoints.points -= 1000;
                Instantiate(pot, new Vector2(-4.723616f, 3.42023f), Quaternion.identity);
                Destroy(gameObject);
                break;
            case 3000:
                checkPoints.points -= 3000;
                Instantiate(pot, new Vector2(-3.251468f, 3.42023f), Quaternion.identity);
                Destroy(gameObject);
                break;
            default:
                nomon.showWarning();
            break;
        }
    }
}
