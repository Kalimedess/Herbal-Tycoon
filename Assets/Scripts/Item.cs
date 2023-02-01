using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Tycoon/New item")]
public class Item : ScriptableObject
{
    [Header("General")]
    public string itemName;
    public int buyprice;
    public int sellprice;
    public int itemamount;
}
