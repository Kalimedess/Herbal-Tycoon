using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Saving
{
    public int[] plantIDs;
    private int lastID=0;
    public float[][] potPositions;
    private int lastPosition=0;
    public float[] plantGrowthTimes;
    private int lastGrowthTime=0;

    public void PotData(PlantManager plant)
    {
        if (plant.TryGetComponent<Plants>(out Plants plantSO))
        {
            plantIDs[lastID] = plantSO.index;
            lastID++;
        }

        potPositions[lastPosition] = new float[2];
        potPositions[lastPosition][0] = plant.transform.position.x;
        potPositions[lastPosition][1] = plant.transform.position.y;
        lastPosition++;

        plantGrowthTimes[lastGrowthTime] = plant.GetTime();
    }
}
