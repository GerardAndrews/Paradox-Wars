using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Conditions : MonoBehaviour {

    //Create the age int
    public int ageLevel;

    //Get all age 2+ building buttons
    public GameObject armoryButton;
    public GameObject fletcherButton;
    public GameObject catapultButton;
    public GameObject tavernButton;
    public GameObject arsenalButton;
    public GameObject cannonButton;

    GameObject other;


    // Use this for initialization
    void Start () {
        ageLevel = 1;

        armoryButton.SetActive(false);
        fletcherButton.SetActive(false);
        catapultButton.SetActive(false);
        tavernButton.SetActive(false);
        arsenalButton.SetActive(false);
        cannonButton.SetActive(false);

        other = GameObject.FindGameObjectWithTag("GameController");
    }
	
	// Update is called once per frame
	void Update () {

        //When age level hits a specific number
        //We want to get more building options active!
        if (ageLevel == 2)
        {
            armoryButton.SetActive(true);
            fletcherButton.SetActive(true);
            catapultButton.SetActive(true);
            tavernButton.SetActive(true);
        }

        if (ageLevel == 3)
        {
            arsenalButton.SetActive(true);
            cannonButton.SetActive(true);
        }

    }

    //Time to advance ages
    public void AdvanceAge()
    {
        // If we have enough gold when we click a button we want to advance to the next age
        if (other.gameObject.GetComponent<GameController>().pOWS <= 29f)
        {
            return;
        }

        else
        {
            ageLevel += 1;
            other.gameObject.GetComponent<GameController>().pOWS -= 30f;
        }
    } 
}
