﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REU3B : MonoBehaviour
{

    //List our death audio here!
    public AudioSource attack;
    public AudioSource impact;


    //List our Projectile list here:
    GameObject[] projectileList;
    int prevCount;


    // Use this for initialization
    void Start()
    {
        projectileList = GameObject.FindGameObjectsWithTag("REU3 Bullet");
        prevCount = projectileList.Length;
    }

    // Update is called once per frame
    void Update()
    {
        projectileList = GameObject.FindGameObjectsWithTag("REU3 Bullet");

        // If the list goes down by 1
        if (projectileList.Length < prevCount)
        {
            // Play a sound
            PlayImpact();
            prevCount = projectileList.Length;
        }

        if (projectileList.Length > prevCount)
        {
            prevCount = projectileList.Length;
        }

        // If the list goes up by 1
        if (projectileList.Length > prevCount)
        {
            // Play a sound
            PlayAttack();
            prevCount = projectileList.Length;
        }

        if (projectileList.Length > prevCount)
        {
            prevCount = projectileList.Length;
        }

    }

    void PlayAttack()
    {
        attack.Play();
    }

    void PlayImpact()
    {
        impact.Play();
    }
}
