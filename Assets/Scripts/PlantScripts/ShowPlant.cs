using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class ShowPlant : MonoBehaviour
{
    public event EventHandler OnHarvested;
    public event EventHandler OnHarvestedRotten;

    private BoxCollider2D _collider;
    [SerializeField] private float time;
    [SerializeField] private bool readyToHarvest = false;
    [SerializeField] private bool isRotten = false;
    [SerializeField] private bool timerActive = true;
    [SerializeField] private float stageGrowLimit = 0;
    private int index = 1;
    private SpriteRenderer currentSprite;
    [SerializeField] public float dehydrationTime;
    [SerializeField] private Plants plant;
    [SerializeField] public float dehydrationTimeWarningPercentage = 0.2f;
    [SerializeField] private GameObject dehydrationWarning;


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
        _collider = GetComponent<BoxCollider2D>();
        dehydrationWarning.SetActive(false);
    }
    private void InitializeGrowing()
    {
        stageGrowLimit = plant.growTime / (plant.sprites.Length - 2f);
        currentSprite.sprite = plant.sprites[0];
        dehydrationTime = plant.wateredTime;
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
        if (plant.IsUnityNull())
        {
            TimeReset();
            index = 1;
            stageGrowLimit = 0;
        }
        else {
            if (timerActive && !isRotten)
            {
                time += Time.deltaTime;
                dehydrationTime -= Time.deltaTime;
            }

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

            if(dehydrationTime <= dehydrationTimeWarningPercentage*plant.wateredTime) {
                dehydrationWarning.SetActive(true);
            }
            else if(dehydrationWarning.activeSelf==true)
            {
                dehydrationWarning.SetActive(false);
            }

            if (dehydrationTime <= 0)
            {
                readyToHarvest = true;
                currentSprite.sprite = plant.sprites[plant.sprites.Length - 1];
                isRotten = true;
            }
        }
    }
    private void OnMouseDown()
    {
        if (readyToHarvest && !isRotten)
        {
            OnHarvested?.Invoke(this, EventArgs.Empty);
            dehydrationWarning.SetActive(false);
        }
        if (readyToHarvest && isRotten)
        {
            OnHarvestedRotten?.Invoke(this, EventArgs.Empty);
            dehydrationWarning.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!plant.IsUnityNull())
            if (!isRotten)
                dehydrationTime = plant.wateredTime;
        
    }
}
