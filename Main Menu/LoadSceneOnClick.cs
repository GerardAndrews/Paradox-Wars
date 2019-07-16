using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

    //Change up the SCENE.
	public void LoadByIndex (int sceneIndex) {
        SceneManager.LoadScene (sceneIndex);
	}

}
