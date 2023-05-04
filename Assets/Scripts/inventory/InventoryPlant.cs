using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Plant", menuName = "Inventory Plant")]
public class InventoryPlant : ScriptableObject
{
    public string plantName;
    public int sellPrice;
    public int buyPrice;
    public Sprite[] sprites;
    public string description;
    public int index;
}
