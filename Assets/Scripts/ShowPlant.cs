using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class ShowPlant : MonoBehaviour
{
    [Header("Public Variables")]
    public float time;
    public bool readyToHarvest = false;
    public bool isRotten = false;
    public event EventHandler OnHarvested;
    public event EventHandler OnHarvestedRotten;
    [Header("Private Variables")]
    [SerializeField] private bool timerActive = true;
    [SerializeField] private float stageGrowLimit = 0;
    [SerializeField] private int index = 1;
    [SerializeField] private int temp;
    [SerializeField] private SpriteRenderer currentSprite;
    [SerializeField] private Plants plant;
    [SerializeField] private bool harvested;


    IEnumerator waiter()
    {
        currentSprite.sprite = plant.sprites[index];
        index++;
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
        stageGrowLimit = plant.growTime / (plant.sprites.Length - 2f);
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
        time = 0f;
        timerActive = true;
    }
    void Update()
    {
        if (timerActive && !isRotten)
        {
            time += Time.deltaTime;
        }
        if (plant.IsUnityNull())
        {
            TimeReset();
            index = 1;
            stageGrowLimit = 0;
        }
        else { 
            if (stageGrowLimit == 0)
            {
                InitializeGrowing();
            }
            if (stageGrowLimit < time)
            {
                StartCoroutine(waiter());
                if (currentSprite.sprite != plant.sprites[plant.sprites.Length - 2])
                {
                    stageGrowLimit += plant.growTime / (plant.sprites.Length - 2f);
                }
            }
            if (plant.dieTime < time)
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
