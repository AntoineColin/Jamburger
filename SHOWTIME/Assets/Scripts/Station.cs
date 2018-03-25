using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour {
    public Transform IncrementStation;
    public Transform DecrementStation;
    public Transform Player;
    public bool transport;
    GameObject pickup;

    void Start () {
        transport = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.position,transform.position)<=2.5) {
            if (Input.GetButtonDown("Decrement"))
            {
                if (pickup != null)
                {
                    pickup.transform.position = IncrementStation.position;
                }
                if (IncrementStation.GetComponent<Station>().pickup != null)
                {

                    IncrementStation.GetComponent<Station>().pickup.transform.position = IncrementStation.GetComponent<Station>().IncrementStation.position;
                }
                if (DecrementStation.GetComponent<Station>().pickup != null)
                {

                    DecrementStation.GetComponent<Station>().pickup.transform.position = DecrementStation.GetComponent<Station>().IncrementStation.position;
                }
            }
            if (Input.GetButtonDown("Increment"))
            {
                if (pickup != null)
                {

                    pickup.transform.position = DecrementStation.position;
                }
                if (IncrementStation.GetComponent<Station>().pickup != null)
                {

                    IncrementStation.GetComponent<Station>().pickup.transform.position = IncrementStation.GetComponent<Station>().DecrementStation.position;
                }
                if (DecrementStation.GetComponent<Station>().pickup != null)
                {

                    DecrementStation.GetComponent<Station>().pickup.transform.position = DecrementStation.GetComponent<Station>().DecrementStation.position;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            pickup = collision.gameObject;
            transport = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            pickup = null;
            transport = false;
            //Debug.Log(transport);
        }
    }
}
