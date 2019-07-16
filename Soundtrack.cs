using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : MonoBehaviour {
    public AudioSource soundtrack;
    public AudioClip medAgeAS;
    public AudioClip renAgeAS;

    GameObject gameController;

    // Use this for initialization
    void Start () {
		gameController = GameObject.FindGameObjectWithTag("GameController");
    }
	
	// Update is called once per frame
	void Update () {

		if (gameController.GetComponent<Building_Conditions>().ageLevel == 2)
        {
            soundtrack.Pause();
            soundtrack.clip = medAgeAS;
            soundtrack.Play();
        }

        if (gameController.GetComponent<Building_Conditions>().ageLevel == 3)
        {
            soundtrack.Pause();
            soundtrack.clip = renAgeAS;
            soundtrack.Play();
        }

    }
}
