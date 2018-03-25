using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class Manager : MonoBehaviour {

	public void Choice (float value){
		if (value > 999) {
			SceneManager.LoadScene ("scene test");
			Debug.Log ("Play");
		}
		if (value < 2) {
			Application.Quit ();
			Debug.Log ("Exit");
		}
	}
}
