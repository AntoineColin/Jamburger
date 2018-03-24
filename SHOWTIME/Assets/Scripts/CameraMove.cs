using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public float smoothSpeed;
	public float xLiberty = 10;
	public float yLiberty = 5;
	public float waitTime = 2;
	
	float stop;
	float maxDistX;
	float maxDistY;
	public Transform player; 
	float distX;
	float distY;
	float myX;
	float myY;
	
	float moveXV;
	float moveYV;
	
	// Update is called once per frame
	void Update () {
		maxDistX = Mathf.Abs (xLiberty);
		maxDistY = Mathf.Abs (yLiberty);
		//calculate the X and Y distance from the camera
		distX = Mathf.Abs(player.position.x - transform.position.x);
		distY = Mathf.Abs(player.position.y - transform.position.y);

		// Check to see if the player is outside max distances
		if (distX > maxDistX) {
			myX = Mathf.SmoothDamp(transform.position.x , player.position.x, ref moveXV, smoothSpeed);
			transform.position = new Vector3(myX, transform.position.y, transform.position.z);
		}
			
		if (distY > maxDistY) {
			myY = Mathf.SmoothDamp(transform.position.y , player.position.y,ref moveYV, smoothSpeed);
			transform.position = new Vector3(transform.position.x, myY, transform.position.z);
		}


	}
}
	
