using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pVoices : MonoBehaviour {

    //List our death audio here!
    public AudioSource dead;
    public AudioSource dead2;
    AudioSource[] deathSounds;


    //List our Unit list here:
    GameObject[] armyList;
    int prevCount;


	// Use this for initialization
	void Start () {
        // Setup the source
        deathSounds = GetComponents<AudioSource>();

        // Link sounds to the source
        dead = deathSounds[0];
        dead2 = deathSounds[1];

        armyList = GameObject.FindGameObjectsWithTag("pUnit");
        prevCount = armyList.Length;
	}
	
	// Update is called once per frame
	void Update () {
        armyList = GameObject.FindGameObjectsWithTag("pUnit");

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
        {
            // We are going to randomly select between sounds to vary audio!
            int randNum = Random.Range(1, 2);
            if (randNum == 1)
            {
                dead.Play();
            }
            else
            {
                dead2.Play();
            }
        }
    }
}
