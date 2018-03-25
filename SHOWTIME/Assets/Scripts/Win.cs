using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {
    public int win;
    public int curwin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (win == curwin)
        {
            SceneManager.LoadScene("MainMenu");
        }
	}
}
