using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public GameObject PlayerPast;
    public GameObject PlayerPresent;
    public GameObject PlayerFuture;
    public Material diffuse;
    public Material sprite;
    int counter = 0;
    // Use this for initialization
    void Start () {
        SleepPlayer(1);
        SleepPlayer(2);

    }

    // Update is called once per frame
    void Update()
    {
        //Switch Players
        if (Input.GetButtonDown("Fire1")){
            if (counter == 2)
            {
                SleepPlayer(counter);
                counter = 0;
                WakePlayer(counter);
            }
            else
            {
                SleepPlayer(counter);
                counter += 1;
                WakePlayer(counter);
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (counter == 0)
            {
                SleepPlayer(counter);
                counter = 2;
                WakePlayer(counter);
            }
            else
            {
                SleepPlayer(counter);
                counter -= 1;
                WakePlayer(counter);
            }
        }
        
    }
    //Wake Player
    void WakePlayer(int counter)
    {
        if (counter == 0)
        {
            PlayerPast.GetComponent<SpriteRenderer>().material = sprite;
        }
        else if (counter == 1)
        {
            PlayerPresent.GetComponent<SpriteRenderer>().material = sprite;
        }
        else
        {
            PlayerFuture.GetComponent<SpriteRenderer>().material = sprite;
        }
    }
    //Sleep Player
    void SleepPlayer(int counter)
    {
        if (counter == 0)
        {
            PlayerPast.GetComponent<SpriteRenderer>().material = diffuse;
        }
        else if (counter == 1)
        {
            PlayerPresent.GetComponent<SpriteRenderer>().material = diffuse;
        }
        else
        {
            PlayerFuture.GetComponent<SpriteRenderer>().material = diffuse;
        }
    }
}
