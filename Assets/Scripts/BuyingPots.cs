using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingPots : MonoBehaviour
{
    private Points checkPoints;
    private NoMoney nomon;
    public GameObject pot;
    private void Start()
    {
        checkPoints = GetComponent<Points>();
        pot = GetComponent<GameObject>();
        nomon = GetComponent<NoMoney>();
    }
    public void buy()
    {
        switch (checkPoints.points) {
            case 100f:
                checkPoints.points -= 100f;
                Instantiate(pot, new Vector2(-4.723616f, 0.9894762f), Quaternion.identity);
                Destroy(gameObject);
            break;
            case 300f:
                checkPoints.points -= 300f;
                Instantiate(pot, new Vector2(-3.251468f, 0.9894762f), Quaternion.identity);
                Destroy(gameObject);
                break;
            case 1000f:
                checkPoints.points -= 1000f;
                Instantiate(pot, new Vector2(-4.723616f, 3.42023f), Quaternion.identity);
                Destroy(gameObject);
                break;
            case 3000f:
                checkPoints.points -= 3000f;
                Instantiate(pot, new Vector2(-3.251468f, 3.42023f), Quaternion.identity);
                Destroy(gameObject);
                break;
            default:
                nomon.showWarning();
            break;
        }
    }
}
