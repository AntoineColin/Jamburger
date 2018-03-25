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
            Debug.Log("cool");
            done = true;

        } else
        {
            done = false;
        }
        if (done)
        {
            treeTop.SetActive(true);
            treeTrunk.SetActive(true);
            smalltree.SetActive(true);
        } else
        {
            treeTop.SetActive(false);
            treeTrunk.SetActive(false);
            smalltree.SetActive(false);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Bucket")
        {
            if (collision.GetComponent<Bucket>().done)
            {
                bucket = true;
                collision.GetComponent<Bucket>().GetComponent<SpriteRenderer>().sprite = collision.GetComponent<Bucket>().unfilled;
                collision.GetComponent<Bucket>().done = false;
            }
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

}


