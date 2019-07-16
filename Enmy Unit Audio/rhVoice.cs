using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhVoice : MonoBehaviour
{

    //List our death audio here!
    public AudioSource dead;


    //List our Unit list here:
    GameObject[] armyList;
    int prevCount;


    // Use this for initialization
    void Start()
    {
        armyList = GameObject.FindGameObjectsWithTag("Helicopter Rat");
        prevCount = armyList.Length;
    }

    // Update is called once per frame
    void Update()
    {
        armyList = GameObject.FindGameObjectsWithTag("Helicopter Rat");

        // If the list goes down by 1
        if (armyList.Length < prevCount)
        {
            // Play a sound
            PlaySound();
            prevCount = armyList.Length;
        }

        if (armyList.Length > prevCount)
        {
            prevCount = armyList.Length;
        }

    }

    void PlaySound()
    {
        dead.Play();
    }
}
