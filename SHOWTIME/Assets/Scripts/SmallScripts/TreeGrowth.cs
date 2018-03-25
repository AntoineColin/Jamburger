using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrowth : MonoBehaviour {
    bool bucket = false;
    bool seed = false;
    bool done = false;
    public GameObject treeTop;
    public GameObject treeTrunk;
    public GameObject smalltree;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(bucket && seed)
        {
            done = true;

        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Bucket")
        {
 
            bucket = true;
        }
        if (collision.name == "Seed")
        {

            seed = true;
        }
    }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.name == "Bucket")
            {
                bucket = false;
            }
            if (collision.name == "Seed")
            {
                seed = false;
            }
        }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (done && collision.gameObject.layer == 8)
        {
            treeTop.SetActive(true);
            treeTrunk.SetActive(true);
            smalltree.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}


