using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Harvesting : MonoBehaviour
{
    public SpriteRenderer[] sprite;
    private Points pont;

    private void Start()
    {
        pont = GetComponent<Points>();
        sprite = GetComponentsInChildren<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        int last = sprite.Length - 1;
        if (sprite[last].enabled)
        {
            pont.points += 100;
            Destroy(gameObject);
        }
    }
}
