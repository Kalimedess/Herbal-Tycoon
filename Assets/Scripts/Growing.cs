using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Growing : MonoBehaviour
{
    public float fullyGrownLimit;
    public float mediumGrownLimit;
    public SpriteRenderer spriteSmall;
    public SpriteRenderer spriteMedium;
    public SpriteRenderer spriteLarge;
    private ParticleSystem[] confetti;
    public float time;
    private bool readyToHarvest;

    // Start is called before the first frame update
    void Start()
    {
        spriteSmall.enabled = true;
        spriteMedium.enabled = false;
        spriteLarge.enabled = false;
        confetti = GetComponentsInChildren<ParticleSystem>();
        for(int i = 0; i < confetti.Length; i++)
        {
            confetti[i].Pause();
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (mediumGrownLimit < time && fullyGrownLimit > time)
        {
            spriteSmall.enabled = false;
            spriteMedium.enabled = true;
            spriteLarge.enabled = false;
        }
        else if(fullyGrownLimit < time && mediumGrownLimit < time)
        {
            spriteSmall.enabled = false;
            spriteMedium.enabled = false;
            spriteLarge.enabled = true;
            for (int i = 0; i < confetti.Length; i++)
            {
                confetti[i].Play();
            }
            for (int i = 0; i < confetti.Length; i++)
            {
                if (!confetti[i].isStopped) { 
                confetti[i].gameObject.SetActive(false);
                }
            }
        }
    }
}