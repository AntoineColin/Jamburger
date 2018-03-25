using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour {

	public Color day;
	public Color twilight;
	public Color night;
	public Color dawn;
	public float dl;
	Camera cam;

	void Start(){
		cam = GetComponent<Camera> ();
		cam.backgroundColor = day;
	}

	public void ChangeColor(float value){
		float hour = value % (4*dl);
		float grad = value % dl;
		Color final;
		if(hour< dl){
			final = Color.Lerp (day,twilight,grad/ dl);
		}else if(hour< 2*dl){
			final = Color.Lerp (twilight,night,grad/ dl);
		}else if(hour< 3*dl){
			final = Color.Lerp (night, dawn, grad/ dl);
		}else{
			final = Color.Lerp (dawn, day, grad/ dl);
		}
		cam.backgroundColor = final;
	}
}
