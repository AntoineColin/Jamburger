using System;
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
        WakePlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        //I will deal with this exception in the game management system or a
        //seperate system to handle errors I just don't want to have multiple players
        //playable and no players playable be a game breaking problem but Maybe
        //we should just handle it here IDK
        bool PlayerFutureMoving = PlayerFuture.GetComponent<PlayerController>().CanMove;
        bool PlayerPresentMoving = PlayerPresent.GetComponent<PlayerController>().CanMove;
        bool PlayerPastMoving = PlayerPast.GetComponent<PlayerController>().CanMove;
        if (!(PlayerPastMoving || PlayerFutureMoving || PlayerPresentMoving))
        {
            //either we throw an exception or just handle
            SleepPlayer(1);
            SleepPlayer(2);
            WakePlayer(0);
            throw new Exception("No player is playable");
        }

        if (Utilities.TernaryXor(PlayerFutureMoving, PlayerPresentMoving, PlayerPastMoving) == false)
        {
            if (PlayerPresentMoving)
            {
                SleepPlayer(0);
                SleepPlayer(2);
                WakePlayer(1);
            }
            else
            {
                SleepPlayer(1);
                SleepPlayer(2);
                WakePlayer(0);
            }
        }

        //Switch Players
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
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
        if (Input.GetKeyDown(KeyCode.RightArrow))
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
            PlayerPast.GetComponent<PlayerController>().CanMove = true;
            PlayerPast.GetComponent<SpriteRenderer>().material = sprite;
        }
        else if (counter == 1)
        {
            PlayerPresent.GetComponent<PlayerController>().CanMove = true;
            PlayerPresent.GetComponent<SpriteRenderer>().material = sprite;
        }
        else
        {
            PlayerFuture.GetComponent<PlayerController>().CanMove = true;
            PlayerFuture.GetComponent<SpriteRenderer>().material = sprite;
        }
    }
    //Sleep Player
    void SleepPlayer(int counter)
    {
        if (counter == 0)
        {
            PlayerPast.GetComponent<PlayerController>().CanMove = false;
            PlayerPast.GetComponent<SpriteRenderer>().material = diffuse;
        }
        else if (counter == 1)
        {
            PlayerPresent.GetComponent<PlayerController>().CanMove = false;
            PlayerPresent.GetComponent<SpriteRenderer>().material = diffuse;
        }
        else
        {
            PlayerFuture.GetComponent<PlayerController>().CanMove = false;
            PlayerFuture.GetComponent<SpriteRenderer>().material = diffuse;
        }
    }
}