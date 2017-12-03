using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void ChangeScene(string sceneName){
		Debug.Log ("Changing scene to" + sceneName);
		SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
	}

	void Update() {
		if (Input.GetKey ("escape")) {
			Quit ();
		}
	}
	public void Quit(){
		Debug.Log ("quit the game");
		Application.Quit();
	}
}
