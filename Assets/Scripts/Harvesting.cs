using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Harvesting : MonoBehaviour
{
    private ShowPlant plantState;
    private SpriteRenderer currentSprite;



    private void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();
        plantState = GetComponent<ShowPlant>();
    }
    private void OnMouseDown()
    {
        if (plantState.readyToHarvest)
        {
            currentSprite.sprite = null;
            plantState.readyToHarvest = false;
        }
    }
}
