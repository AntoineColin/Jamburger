using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
	PlayerController Player;
	public bool CanMove = false;
	public float speed;

	Vector2 startPosition;
	private Vector2 pos;
	
	private Transform body;

	private static float JUMPHEIGHT = 4;
	
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
			float moveVertical = rb2d.velocity.y;
			
			if (Input.GetKeyDown(KeyCode.W))
			{
				moveVertical += Vector2.up.y * JUMPHEIGHT;
			}

			rb2d.velocity = new Vector2(moveHorizontal*speed, moveVertical);
			
		}
	}
}