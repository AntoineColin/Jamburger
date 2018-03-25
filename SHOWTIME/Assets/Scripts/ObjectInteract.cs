using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class ObjectInteract : MonoBehaviour {
    GameObject Manager;
	AudioSource source;
    
    public enum Time {Past, Present, Future};
    public Time timeline;
    int counter;
    // Use this for initialization
    void Start () {
        Manager = GameObject.Find("PlayerManager");
		source = GetComponent<AudioSource> ();
		if (timeline == Time.Past)
        {
            counter = 0;
        }
        else if (timeline == Time.Present)
        {
            counter = 1;
        }
        else
        {
            counter = 2;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (counter == Manager.GetComponent<PlayerManager>().counter) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 2);
            if (Input.GetButtonDown("Interact") && hit != null)
            {
                //Debug.Log(hit.collider.gameObject.name);

            }
        }
	}
}
