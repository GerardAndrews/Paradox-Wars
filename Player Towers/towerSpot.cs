using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerSpot : MonoBehaviour
{
    GameObject[] arrowTowers;
    GameObject[] catapultList;
    GameObject other;
    GameObject costObject;

    void Start()
    {
        other = GameObject.FindGameObjectWithTag("GameController");
        arrowTowers = GameObject.FindGameObjectsWithTag("aTower");
        catapultList = GameObject.FindGameObjectsWithTag("Catapult");
    } 

    void Update()
    {
        arrowTowers = GameObject.FindGameObjectsWithTag("aTower");
        catapultList = GameObject.FindGameObjectsWithTag("Catapult");
    }

    void OnMouseUp()
    {
        Debug.Log("Tower spot clicked");

        Building_Manager bm = GameObject.FindObjectOfType<Building_Manager>();
        if(bm.selectedBuilding != null)
        {
            //If we have enough money
            if (other.gameObject.GetComponent<GameController>().money >= bm.selectedBuilding.gameObject.GetComponent<Sell>().cost)
            {
                //If we are building a tower
                if (bm.selectedBuilding.tag == "aTower")
                {
                    // If we have 3 or less arrow towers
                    if (arrowTowers.Length == 3)
                    {
                        return;
                    }

                    else
                    {
                        //Replace the tower plot with an actual tower
                        Instantiate(bm.selectedBuilding, this.transform.position, this.transform.rotation);
                        Destroy(gameObject);

                        //Subtract gold
                        other.gameObject.GetComponent<GameController>().money -= bm.selectedBuilding.gameObject.GetComponent<Sell>().cost;
                    }
                }

                else if (bm.selectedBuilding.tag == "Catapult")
                {
                    // If we have 2 or less catapults
                    if (catapultList.Length == 2)
                    {
                        return;
                    }

                    else
                    {
                        //Replace the tower plot with an actual tower
                        Instantiate(bm.selectedBuilding, this.transform.position, this.transform.rotation);
                        Destroy(gameObject);

                        //Subtract gold
                        other.gameObject.GetComponent<GameController>().money -= bm.selectedBuilding.gameObject.GetComponent<Sell>().cost;
                    }
                }
                else
                {
                    //Replace the tower plot with an actual building
                    Instantiate(bm.selectedBuilding, this.transform.position, this.transform.rotation);
                    Destroy(gameObject);

                    //Subtract gold
                    other.gameObject.GetComponent<GameController>().money -= bm.selectedBuilding.gameObject.GetComponent<Sell>().cost;
                }
            }

            else
            {
                //Tell the player he doesn't have enough money
                Debug.Log("Not enough money!");
            }
        }
    }
}