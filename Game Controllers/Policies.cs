using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Policies : MonoBehaviour {

    // Link the building condition script
    GameObject buildingConditions;

    // Setup Policy Buttons
    public GameObject medievalPolicyGO;
    public Text medText;

    //  Ransom Economy Button
    public GameObject ransomEconomyButton;
    public GameObject sellPOWButton;

    //  Beast Taming Button
    public GameObject beastTamingButton;
    public GameObject recruitBeastButton;

    // Setip New Policy Buttons
    public GameObject renaissancePolicyGO;
    public Text renText;

    public GameObject conscriptionButton;
    public GameObject eliteTrainingButton;

    public bool conscription;
    public bool eliteTraining;

    public Text cText;
    public Text etText;


    // Use this for initialization
    void Start () {
        buildingConditions = GameObject.FindGameObjectWithTag("GameController");
    }
	
	// Update is called once per frame
	void Update () {
        if (buildingConditions.GetComponent<Building_Conditions>().ageLevel == 2)
        {
            // Your first advance age will introduce the mechanic
            medievalPolicyGO.SetActive(true);
        }
        else if (buildingConditions.GetComponent<Building_Conditions>().ageLevel == 3)
        {
            // All medieval buttons are stopped after you hit renaissance
            medievalPolicyGO.SetActive(false);
            renaissancePolicyGO.SetActive(true);
        }

        else
        {
            // We want all buttons to be disabled at the start
            medievalPolicyGO.SetActive(false);
            renaissancePolicyGO.SetActive(false);
        }
    }

    // Activate the button for ransom economy policy
    public void RansomEconomy()
    {
        beastTamingButton.SetActive(false);
        ransomEconomyButton.SetActive(false);
        medText.gameObject.SetActive(false);
        sellPOWButton.SetActive(true);
    }

    // Activate the button for the beast taming policy
    public void BeastTaming()
    {
        beastTamingButton.SetActive(false);
        ransomEconomyButton.SetActive(false);
        recruitBeastButton.SetActive(true);
        medText.gameObject.SetActive(false);
    }

    public void Conscription()
    {
        renText.gameObject.SetActive(false);
        conscriptionButton.SetActive(false);
        eliteTrainingButton.SetActive(false);
        cText.gameObject.SetActive(true);
        conscription = true;
}

    public void Trained()
    {
        renText.gameObject.SetActive(false);
        conscriptionButton.SetActive(false);
        eliteTrainingButton.SetActive(false);
        etText.gameObject.SetActive(true);
        eliteTraining = true;
    }
}
