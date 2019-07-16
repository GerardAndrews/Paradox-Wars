using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    // public GameObject loadScreen;
    public GameObject pBase;
    public GameObject eBase;

    // Use this for initialization
    void Start ()
    {
        // loadScreen.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
        if(pBase == null)
        {
            LoadDefeat();
        }

        if (eBase == null)
        {
            LoadVictory();
        }
	}

    void LoadVictory()
    {
        SceneManager.LoadScene(2);
    }

    void LoadDefeat()
    {
        SceneManager.LoadScene(3);
    }
}

