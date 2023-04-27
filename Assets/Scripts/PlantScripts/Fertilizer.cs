using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fertilizer", menuName = "Fertilizer")]
public class Fertilizer : ScriptableObject
{
    public float growthMultiplier;
    public int fertilizerDuration;
}
