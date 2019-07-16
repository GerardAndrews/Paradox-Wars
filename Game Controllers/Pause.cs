using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
    bool isPaused;
    public GameObject pauseButton;
    public GameObject resumeButton;

    // Use this for initialization
    void Start () {
        isPaused = false;
        resumeButton.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (isPaused == true)
        {
            Time.timeScale = 0;
            pauseButton.SetActive(false);
            resumeButton.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseButton.SetActive(true);
            resumeButton.SetActive(false);
        }
		
	}

    public void Pausing() {
     isPaused = true;
        
    }

    public void Resume()
    {
            isPaused = false;
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }
   
}
