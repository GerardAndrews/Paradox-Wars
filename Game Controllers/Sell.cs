using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sell : MonoBehaviour {

    public GameObject plot;
    public float cost;
    GameObject other;

    void Start()
    {
        other = GameObject.FindGameObjectWithTag("GameController");
    }

    void OnMouseUp()
    {

        // Replace the building with a tower plot
        Instantiate(plot, this.transform.position, this.transform.rotation);
        Destroy(gameObject);

        //Subtract gold
        other.gameObject.GetComponent<GameController>().money += gameObject.GetComponent<Sell>().cost / 2;
    }
}
