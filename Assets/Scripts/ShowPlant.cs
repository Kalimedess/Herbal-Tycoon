using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class ShowPlant : MonoBehaviour
{
    [Header("Public Variables")]
    public int time;
    public bool readyToHarvest = false;
    public bool isRotten = false;
    public event EventHandler OnHarvested;
    public event EventHandler OnHarvestedRotten;
    [Header("Private Variables")]
    [SerializeField] private bool timerActive = true;
    [SerializeField] private int stageGrowLimit=0;
    [SerializeField] private int index = 0;
    [SerializeField] private int temp;
    [SerializeField] private SpriteRenderer currentSprite;
    [SerializeField] private Plants plant;
    [SerializeField] private float timeRaw;
    [SerializeField] private bool harvested;


    IEnumerator waiter()
    {
        currentSprite.sprite = plant.sprites[index];
        index++;
        time += 1;
        yield return new WaitForSeconds(1f);
    }
    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();
        OnHarvested += HarvestDelete;
        OnHarvestedRotten += HarvestDelete;
    }
    private void InitializeGrowing()
    {
        stageGrowLimit = (int)Mathf.Ceil(plant.growTime / (plant.sprites.Length - 1f));
        currentSprite.sprite = plant.sprites[0];
    }
    private void HarvestDelete(object sender, EventArgs e)
    {
        currentSprite.sprite = null;
        readyToHarvest = false;
        plant = null;
        timerActive = false;
        isRotten = false;
    }
    private void TimeReset()
    {
        timeRaw = 0f;
        time = 0;
        timerActive = true;
    }
    void Update()
    {
        if (timerActive && !isRotten)
        {
            timeRaw += Time.deltaTime;
            time = (int)timeRaw;
        }
        if (plant.IsUnityNull())
        {
            TimeReset();
            index = 0;
            stageGrowLimit = 0;
        }
        if (stageGrowLimit == time)
        {
            StartCoroutine(waiter());
            if (currentSprite.sprite != plant.sprites[plant.sprites.Length - 2])
            {
                stageGrowLimit += (int)Mathf.Ceil(plant.growTime / (plant.sprites.Length - 1f));
            }
        }
        if (!plant.IsUnityNull())
        {
            if (stageGrowLimit == 0)
            {
                InitializeGrowing();
            }
            if (plant.dieTime == time)
            {
                currentSprite.sprite = plant.sprites[plant.sprites.Length - 1];
                isRotten = true;
            }
            if (currentSprite.sprite == plant.sprites[plant.sprites.Length - 2])
            {
                readyToHarvest = true;
                stageGrowLimit = plant.dieTime;
            }
        }
    }
    private void OnMouseDown()
    {
        if (readyToHarvest && !isRotten)
        {
            OnHarvested?.Invoke(this, EventArgs.Empty);
        }
        if (readyToHarvest && isRotten)
        {
            OnHarvestedRotten?.Invoke(this, EventArgs.Empty);
        }
    }
}
