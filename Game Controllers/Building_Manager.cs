using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Manager : MonoBehaviour {

    public GameObject selectedBuilding;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    public void changeBuilding(GameObject prefab)
    {
        selectedBuilding = prefab;
    } 
}
