using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Color : MonoBehaviour {

    public Text unitText1;
    public Text unitText2;
    public Text unitText3;
    public Text unitText4;
    public Text unitText5;
    public Text unitText6;
    public Text unitText7;
    public Text unitText8;
    public Text unitText9;
    public Text unitText10;
    public Text unitText11;
    public Text selectPolicyText;
    public Text conText;
    public Text etText;
    public Text conText1;
    public Text etText1;
    public Text build;
    public Text refund;


    GameObject gameController;

    // Use this for initialization
    void Start ()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }
	
	// Update is called once per frame
	void Update () {

        if (gameController.gameObject.GetComponent<Building_Conditions>().ageLevel == 3)
        {
            unitText1.color = Color.white;
            unitText2.color = Color.white;
            unitText3.color = Color.white;
            unitText4.color = Color.white;
            unitText5.color = Color.white;
            unitText6.color = Color.white;
            unitText7.color = Color.white;
            unitText8.color = Color.white;
            unitText9.color = Color.white;
            unitText10.color = Color.white;
            unitText11.color = Color.white;
            selectPolicyText.color = Color.white;
            conText.color = Color.white;
            etText.color = Color.white;
            conText1.color = Color.white;
            etText1.color = Color.white;
            build.color = Color.white;
            refund.color = Color.white;
        }


    }
}
