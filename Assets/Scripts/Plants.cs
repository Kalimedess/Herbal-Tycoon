using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class Plants : ScriptableObject
{
    [SerializeField] public string plantName;
    [SerializeField] public int sellPrice;
    [SerializeField] public int buyPrice;
    [SerializeField] public int quantity;
    [SerializeField] public int growTime;
    [SerializeField] public int dieTime;
    [SerializeField] public Sprite[] sprites;
}
