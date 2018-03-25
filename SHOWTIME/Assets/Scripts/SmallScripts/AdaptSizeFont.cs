using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AdaptSizeFont : MonoBehaviour {

	public int minSize, maxSize;
	Text txtComponent;

	void Start () {
		txtComponent = GetComponent <Text> ();
	}

	public void ChangeSize(float value){
		int grad = (int)(value / 1000 * (maxSize-minSize));
		txtComponent.fontSize = minSize + grad;
	}
}
