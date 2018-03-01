using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageArea: MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Player 1")
        {
            PlayerController pController = col.gameObject.GetComponent<PlayerController>();
            pController._isOutOfArena = false;
            Debug.Log("Player 1 Enter");
        }
        if (col.gameObject.name == "Player 2")
        {
            Player2Controller pController = col.gameObject.GetComponent<Player2Controller>();
            pController._isOutOfArena = false;
            Debug.Log("Player 2 Enter");
        }
        if (col.gameObject.name == "Player 3")
        {
            Player3Controller pController = col.gameObject.GetComponent<Player3Controller>();
            pController._isOutOfArena = false;
            Debug.Log("Player 3 Enter");
        }
        if (col.gameObject.name == "Player 4")
        {
            Player4Controller pController = col.gameObject.GetComponent<Player4Controller>();
            pController._isOutOfArena = false;
            Debug.Log("Player 4 Enter");
        }
        //Add these for all the players
        /*else if (col.gameObject.name == "Player2")
        {
            Player2Controller pController = col.gameObject.GetComponent<Player2Controller>();
            pController._isOutOfArena = false;
            Debug.Log("Player2 Enter");
        }*/

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player 1")
        {
            PlayerController pController = col.gameObject.GetComponent<PlayerController>();
            pController._isOutOfArena = true;
            Debug.Log("Player 1 Exit");
        }
        if (col.gameObject.name == "Player 2")
        {
            Player2Controller pController = col.gameObject.GetComponent<Player2Controller>();
            pController._isOutOfArena = true;
            Debug.Log("Player 2 Exit");
        }
        if (col.gameObject.name == "Player 3")
        {
            Player3Controller pController = col.gameObject.GetComponent<Player3Controller>();
            pController._isOutOfArena = true;
            Debug.Log("Player 3 Exit");
        }
        if (col.gameObject.name == "Player 4")
        {
            Player4Controller pController = col.gameObject.GetComponent<Player4Controller>();
            pController._isOutOfArena = true;
            Debug.Log("Player 4 Exit");
        }
        //Add these for all the players
        /*else if (col.gameObject.tag == "Player2")
        {
            Player2Controller pController = col.gameObject.GetComponent<Player2Controller>();
            pController._isOutOfArena = true;
            Debug.Log("Player2 Exit");
        }*/
    }
}
