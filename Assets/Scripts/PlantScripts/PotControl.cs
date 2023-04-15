using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotControl : MonoBehaviour
{
    [SerializeField] private Pot pot;
    [SerializeField] private SpriteRenderer potImage;

    void Start()
    {
        potImage = GetComponent<SpriteRenderer>();
        potImage.sprite = pot.potSprite;
    }

    void updatePot()
    {
        potImage.sprite = pot.potSprite;
    }

}
