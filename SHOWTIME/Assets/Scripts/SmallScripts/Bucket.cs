using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour {
    public Sprite unfilled;
    public Sprite filled;
    bool inWater;
    public bool done = false;

	AudioSource source;
	public AudioClip splashSound;
	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = unfilled;
		source = GetComponent < AudioSource >();
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Pickup>().pickup == false)
        {
            if (inWater && !done)
            {
                GetComponent<SpriteRenderer>().sprite = filled;
                done = true;
            }
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
		Debug.Log(inWater);
        if(collision.name == "Water")
        {
			
            inWater = true;
			source.PlayOneShot (splashSound);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Water")
        {
            inWater = false;
        }
    }
}
