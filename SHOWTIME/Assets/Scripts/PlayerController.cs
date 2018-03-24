using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using System;

public class PlayerController : MonoBehaviour
{
	PlayerController Player;
	public bool CanMove = false;
	private bool canJump = true;
	public float speed;
	public float jumpHeight = 1000;

	public AudioClip[] footsteps;
	public AudioSource source;
	private bool canPlayFoot = true;

	private Transform body;


	
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

		body = transform;
		rb2d = GetComponent<Rigidbody2D> ();
		source = GetComponent<AudioSource> ();
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
			Vector2 moveVertical = new Vector2(0, Input.GetAxisRaw ("Vertical") * jumpHeight);
			

			//Set to zero the x velocity to disable inertia
			rb2d.velocity = Vector2.Scale (rb2d.velocity, Vector2.up);
			//Add the speed of walking of the character
			rb2d.velocity += new Vector2(moveHorizontal*speed, 0);

			if(canJump){
				Jump (moveVertical);
			}
		}
		/*
		 * PLAYING SOUNDS
		 */
		if(rb2d.velocity.x!=0 && canPlayFoot){
			int rand = UnityEngine.Random.Range (1,footsteps.Length);
			float soundLength = footsteps [rand - 1].length;
			source.PlayOneShot (footsteps[rand-1], 0.6f);
			canPlayFoot = false;
			StartCoroutine (playFootSteps (soundLength));
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

	IEnumerator playFootSteps(float timeToGo){
		
		yield return new WaitForSeconds (timeToGo);
		canPlayFoot = true;
	}
}