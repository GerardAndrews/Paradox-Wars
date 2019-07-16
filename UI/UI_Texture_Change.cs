using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Renaissance : MonoBehaviour {

    GameObject gameController;

	// Use this for initialization
	void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController");

    }
	
	// Update is called once per frame
	void Update () {
        //When we advance the age we need to change the UI background
        if (gameController.gameObject.GetComponent<Building_Conditions>().ageLevel == 2)
        {
            // reveal the UI for medieval
            gameObject.SetActive(false);
        }
		
	}
}
