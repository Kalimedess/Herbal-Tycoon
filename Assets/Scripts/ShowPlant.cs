using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlant : MonoBehaviour
{
    private SpriteRenderer currentSprite;
    [SerializeField] private Plants plant;
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
    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();
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

        if (plant.dieTime == time)
        {
            currentSprite.sprite = plant.sprites[plant.sprites.Length-1];
        }

        if (currentSprite.sprite==plant.sprites[plant.sprites.Length - 2])
        {
            readyToHarvest = true;
        }
    }
}
