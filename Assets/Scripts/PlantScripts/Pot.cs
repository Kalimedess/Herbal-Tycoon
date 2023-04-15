using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pot",menuName = "Pot")]
public class Pot : ScriptableObject
{
    [SerializeField] public Sprite potSprite;
    [SerializeField] public float growthSpeedMultiplier;
}
