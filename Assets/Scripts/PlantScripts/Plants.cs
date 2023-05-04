using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class Plants : ScriptableObject
{
    public string plantName;
    public int growTime;
    public int dieTime;
    public int wateredTime;
    public Sprite[] sprites;
    public int index;
}
