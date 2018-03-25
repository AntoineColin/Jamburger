using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour {
    public Sprite unfilled;
    public Sprite filled;
    bool inWater;
    bool done = false;
	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = unfilled;
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
        if(collision.name == "Water")
        {
            inWater = true;
            //Debug.Log(inWater);
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
