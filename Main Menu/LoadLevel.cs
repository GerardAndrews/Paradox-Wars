using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public GameObject loadingImage;
 
    //Change up the SCENE.
    public void LoadByIndex(int sceneIndex)
    {
        loadingImage.SetActive(true);
        SceneManager.LoadScene(sceneIndex);
    }
}
