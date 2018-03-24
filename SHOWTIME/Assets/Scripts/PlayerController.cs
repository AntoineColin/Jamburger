using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
	PlayerController Player;
	public bool CanMove = false;
	private bool canJump = true;
	public float speed;

	Vector2 startPosition;
	private Vector2 pos;
	
	private Transform body;

	public float JUMPHEIGHT = 4;
	
	private Rigidbody2D rb2d;
	
	// Use this for initialization
	void Awake()
	{
		if (Player == null)
		{
			Player = this;
		}
	}
	void Start () {
		startPosition = this.gameObject.transform.position;
		pos = startPosition;
		body = transform;
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//do nothing yet
	}

	private void FixedUpdate()
	{
		if (CanMove)
		{
			float moveHorizontal = Input.GetAxis("Horizontal");
			Vector2 moveVertical = new Vector2(0, Input.GetAxisRaw ("Vertical") * JUMPHEIGHT);

			//Set to zero the x velocity to disable inertia
			rb2d.velocity = Vector2.Scale (rb2d.velocity, Vector2.up);
			//Add the speed of walking of the character
			rb2d.velocity += new Vector2(moveHorizontal*speed, 0);

			if(canJump){
				Jump (moveVertical);
			}
		}
	}

	void Jump(Vector2 jumpVector){
		//Set to zero the y velocity to disable inertia and to do all the time the same jump
		rb2d.velocity = Vector2.Scale (rb2d.velocity, Vector2.right);
		//Add the vector to jump
		rb2d.velocity += jumpVector;
	}

	void OnTriggerStay2D(Collider2D coll){
		//if it touch the ground it can jump
		canJump = true;
	}

	void OnTriggerExit2D(Collider2D coll){
		//if it isn't on the ground anymore it can't jump
		canJump = false;
	}
}