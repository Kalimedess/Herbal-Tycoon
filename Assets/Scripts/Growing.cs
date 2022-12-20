using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Growing : MonoBehaviour
{
    public float fullyGrownLimit;
    public float mediumGrownLimit;
    public SpriteRenderer spriteSmall;
    public SpriteRenderer spriteMedium;
    public SpriteRenderer spriteLarge;
    private ParticleSystem[] confetti;
    public float timeRaw;
    public int time;
    private BoxCollider2D harvestInteract;

    IEnumerator confettiPlayer()
    {
        for (int i = 0; i < confetti.Length; i++)
        {
            confetti[i].Play();
        }
        yield return new WaitForSeconds(2);
        for (int i = 0; i < confetti.Length; i++)
        {
            confetti[i].gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteSmall.enabled = true;
        spriteMedium.enabled = false;
        spriteLarge.enabled = false;
        harvestInteract = GetComponent<BoxCollider2D>();
        confetti = GetComponentsInChildren<ParticleSystem>();
        for(int i = 0; i < confetti.Length; i++)
        {
            confetti[i].Pause();
        }
        harvestInteract.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        timeRaw += Time.deltaTime;
        time = (int) timeRaw;
        if (mediumGrownLimit == time)
        {
            spriteSmall.enabled = false;
            spriteMedium.enabled = true;
            spriteLarge.enabled = false;
        }
        else if (fullyGrownLimit == time)
        {
            spriteSmall.enabled = false;
            spriteMedium.enabled = false;
            spriteLarge.enabled = true;
            harvestInteract.enabled = true;
            StartCoroutine(confettiPlayer());
        }
        if (harvestInteract.enabled == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                Camera.main.ScreenToWorldPoint(mousePosition);
                Debug.DrawRay(transform.position, mousePosition - transform.position, Color.blue);
                //spriteLarge.enabled = false;

            }
        }
    }
    
}

