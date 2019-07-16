using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {
    // This script interacts with buttons that bring up Recruitment and Building Buttons separately
    public GameObject building_Buttons;
    public GameObject recruitment_Buttons;

    public GameObject buildingAccessButton;
    public GameObject recruitmentAccessButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RecruitmentTab()
    {
        recruitment_Buttons.SetActive(true);
        building_Buttons.SetActive(false);
        buildingAccessButton.SetActive(false);
        recruitmentAccessButton.SetActive(false);
    }

    public void BuildingTab()
    {
        building_Buttons.SetActive(true);
        recruitment_Buttons.SetActive(false);
        buildingAccessButton.SetActive(false);
        recruitmentAccessButton.SetActive(false);
    }

    public void Back()
    {
        building_Buttons.SetActive(false);
        recruitment_Buttons.SetActive(false);
        buildingAccessButton.SetActive(true);
        recruitmentAccessButton.SetActive(true);
    }
}
