using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public float money;
    public float pOWS;
    public float enemyPOWS;
    public Text moneyText;
    public Text powText;

    GameObject gameController;

	// Use this for initialization
	void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        money += Time.deltaTime;
        moneyText.text = "$" + money.ToString();
        powText.text = pOWS.ToString();

        if (gameController.gameObject.GetComponent<Building_Conditions>().ageLevel == 3)
        {
            moneyText.color = Color.white;
            powText.color = Color.white;
        }
    }

    public void SellPOW()
    {
        pOWS -= 1;
        money += 25f;
    }
}
