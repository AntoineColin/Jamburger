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
	float jumpHeight = 20f;
	//public float lowJumpHeight = 2.5f;
	public float fallMultiplier = 500f;

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
		rb2d = GetComponent<Rigidbody2D> ();
	}
	void Start () {

		body = transform;
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
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
 
	private void FixedUpdate()
	{
		//ONLY FOR PHYSICS DON'T PUT ANYTHING ELSE IN HERE OR THERE WILL BE BUGS!!
		if (CanMove)
		{
			float moveHorizontal = Input.GetAxis("Horizontal");

			rb2d.AddForce(Vector2.up*Physics2D.gravity.y*fallMultiplier, ForceMode2D.Force);
			//Set to zero the x velocity to disable inertia
			rb2d.velocity = Vector2.Scale (rb2d.velocity, Vector2.up);
			//rb2d.velocity = Vector2.zero;
			rb2d.velocity += new Vector2(moveHorizontal*speed, 0f);
			//Add the speed of walking of the character
			if(canJump && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))){
				Jump();
			}
		}

	}

	void Jump(){
		//Set to zero the y velocity to disable inertia and to do all the time the same jump
		//rb2d.velocity = Vector2.Scale (rb2d.velocity, Vector2.right);
		//Add the vector to jump
		
		rb2d.velocity += Vector2.up * jumpHeight;
		//rb2d.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
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