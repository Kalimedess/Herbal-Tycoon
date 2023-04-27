using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotControl : MonoBehaviour
{
    [SerializeField] public Pot pot;
    [SerializeField] private Fertilizer fertilizer;
    [SerializeField] private SpriteRenderer potImage;
    private float time=0;
    [SerializeField] public float growthSpeedMultiplier = 1f;

    void Start()
    {
        potImage = GetComponent<SpriteRenderer>();
        potImage.sprite = pot.potSprite;
    }

    void placeFertilizer()
    {
        growthSpeedMultiplier -= fertilizer.growthMultiplier/100;
    }
    void deleteFertilizer()
    {
        fertilizer = null;
        time = 0;
        growthSpeedMultiplier = 1f;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (!fertilizer.IsUnityNull())
        {
            if (growthSpeedMultiplier == 1f)
            {
                placeFertilizer();
            }
            if (time >= fertilizer.fertilizerDuration)
            {
                deleteFertilizer();
            }
        }
    }
}
