using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit_Conditions : MonoBehaviour {

    public GameObject[] barracksPrefab;
    public GameObject[] charioteerPrefab;
    public GameObject[] armoryPrefab;
    public GameObject[] tavernPrefab;
    public GameObject[] fletcherPrefab;
    public GameObject[] arsenalPrefab;
    public GameObject chariotButton;
    public GameObject barracksButton;
    public GameObject knightButton;
    public GameObject ninjaButton;
    public GameObject horseArcherButton;
    public GameObject swordButton;
    public GameObject musketButton;
    public GameObject grenadeButton;
    public GameObject pu3Button;
    public GameObject pu4Button;

    // Use this for initialization
    void Start () {
        barracksButton.SetActive(false);
        chariotButton.SetActive(false);
        horseArcherButton.SetActive(false);
        knightButton.SetActive(false);
        ninjaButton.SetActive(false);
        swordButton.SetActive(false);
        musketButton.SetActive(false);
        grenadeButton.SetActive(false);
        pu3Button.SetActive(false);
        pu4Button.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        BuildingCheck();

        barracksPrefab = GameObject.FindGameObjectsWithTag("Barracks");
        charioteerPrefab = GameObject.FindGameObjectsWithTag("Stables");
        armoryPrefab = GameObject.FindGameObjectsWithTag("Armory");
        tavernPrefab = GameObject.FindGameObjectsWithTag("Tavern");
        fletcherPrefab = GameObject.FindGameObjectsWithTag("Fletcher");
        arsenalPrefab = GameObject.FindGameObjectsWithTag("Arsenal");




    }
    void BuildingCheck()
    {
        if (barracksPrefab.Length >= 1)
        {
            barracksButton.SetActive(true);
        }
        else
        {
            barracksButton.SetActive(false);
        }

        if (charioteerPrefab.Length >= 1)
        {
            chariotButton.SetActive(true);
        }
        else
        {
            chariotButton.SetActive(false);
        }

        if (charioteerPrefab.Length >= 1 && fletcherPrefab.Length >= 1)
        {
            horseArcherButton.SetActive(true);
        }

        else
        {
            horseArcherButton.SetActive(false);
        }

        if (barracksPrefab.Length >= 1 && armoryPrefab.Length >= 1)
        {
            swordButton.SetActive(true);
        }

        else
        {
            swordButton.SetActive(false);
        }
        if (tavernPrefab.Length >= 1)
        {
            ninjaButton.SetActive(true);
        }

        else
        {
            ninjaButton.SetActive(false);
        }
        if (charioteerPrefab.Length >= 1 && armoryPrefab.Length >= 1)
        {
            knightButton.SetActive(true);
        }

        else
        {
            knightButton.SetActive(false);
        }

        if (armoryPrefab.Length >= 1 && arsenalPrefab.Length >= 1)
        {
            grenadeButton.SetActive(true);
        }
        else
        {
            grenadeButton.SetActive(false);
        }

        if (barracksPrefab.Length >= 1 && arsenalPrefab.Length >= 1)
        {
            musketButton.SetActive(true);
        }
        else
        {
            musketButton.SetActive(false);
        }

        if (charioteerPrefab.Length >= 1 && arsenalPrefab.Length >= 1)
        {
            pu3Button.SetActive(true);
        }
        else
        {
            pu3Button.SetActive(false);
        }

        if (tavernPrefab.Length >= 1 && arsenalPrefab.Length >= 1)
        {
            pu4Button.SetActive(true);
        }
        else
        {
            pu4Button.SetActive(false);
        }
    }
}
