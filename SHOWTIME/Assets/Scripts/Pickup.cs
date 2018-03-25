using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    GameObject Manager;
    public bool pickup = false;
    public enum Time { Past, Present, Future };
    public Time timeline;
    public int counter;
    public GameObject following;
    Vector3 sScale;
    public Vector3 smallScale = new Vector3(2,2,2);
    // Use this for initialization
    void Start()
    {
        sScale = transform.localScale;
        Manager = GameObject.Find("PlayerManager");
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
    void Update()
    {
        //Debug.Log(counter);
        if (following == null || following.tag !="Player")
        {
            pickup = false;
            following = null;
        }
        if (pickup)
        {
            transform.position = following.transform.position;
            
        }
        
        //if (counter == Manager.GetComponent<PlayerManager>().counter)
        //{
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 2);
           
        if (Input.GetButtonDown("Interact") && !pickup)
            {
               // Debug.Log(hit.collider.gameObject.name);
                pickup = true;

                following = hit.transform.gameObject;

               // Debug.Log(pickup);
                transform.localScale = smallScale;
                GetComponent<SpriteRenderer>().sortingOrder = 1;

            }else 
                if (Input.GetButtonDown("Interact") && pickup)
                {
                    pickup = false;
                    following = null;
               // Debug.Log(pickup);
                transform.localScale = sScale;
                GetComponent<SpriteRenderer>().sortingOrder= -1;
            }
            //}
    }
}
