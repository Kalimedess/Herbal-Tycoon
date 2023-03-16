using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowPlant : MonoBehaviour
{
    private SpriteRenderer currentSprite;
    [SerializeField] private Plants plant;
    private Harvesting harvest;
    private float timeRaw;
    public int time;
    private int stageGrowLimit;
    private int index=1;
    private int temp;
    public bool readyToHarvest=false;
    

    IEnumerator waiter()
    {
        currentSprite.sprite = plant.sprites[index];
        index++;
        yield return new WaitForSeconds(1f);
    }
    private bool isPlantNotAssigned(Plants plant) => plant.IsUnityNull();
    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();
        harvest = GetComponent<Harvesting>();
        stageGrowLimit = plant.growTime / (plant.sprites.Length - 1);
        currentSprite.sprite = plant.sprites[0];
    }

    void Update()
    {
        timeRaw += Time.deltaTime;
        time = (int)timeRaw;

        if (stageGrowLimit == time)
        {
            StartCoroutine(waiter());
            stageGrowLimit += stageGrowLimit;
        }

        if (!isPlantNotAssigned(plant))
        {
            if (plant.dieTime == time)
            {
                currentSprite.sprite = plant.sprites[plant.sprites.Length - 1];
            }

            if (currentSprite.sprite == plant.sprites[plant.sprites.Length - 2])
            {
                readyToHarvest = true;
            }
        }
        
        if (harvest.harvested == true)
        {
            plant = null;
        }
    }
}
