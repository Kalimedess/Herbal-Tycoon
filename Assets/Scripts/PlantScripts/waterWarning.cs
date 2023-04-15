using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterWarning : MonoBehaviour
{
    private ShowPlant plant;
    private Plants plantStats;
    private GameObject sprite;

    private void Start()
    {
        sprite = GetComponentInChildren<GameObject>();
        sprite.SetActive(false);
    }
    private void Update()
    {
        if (plant.dehydrationTime <= plantStats.wateredTime * plant.dehydrationTimeWarningPercentage)
        {
            sprite.SetActive(true);
        }
    }
}
