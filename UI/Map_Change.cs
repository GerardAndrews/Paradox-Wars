using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Change : MonoBehaviour {

    GameObject gameController;
    SpriteRenderer sr;
    public Sprite medMap;
    public Sprite renMap;

    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameController.gameObject.GetComponent<Building_Conditions>().ageLevel == 2)
        {
            sr.sprite = medMap;
        }

        if (gameController.gameObject.GetComponent<Building_Conditions>().ageLevel == 3)
        {
            sr.sprite = renMap;
        }

    }
}
