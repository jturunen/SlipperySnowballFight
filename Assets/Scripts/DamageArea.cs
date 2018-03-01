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
        if(col.gameObject.name == "Player")
        {
            PlayerController pController = col.gameObject.GetComponent<PlayerController>();
            pController._isOutOfArena = false;
            Debug.Log("Player Enter");
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
        if (col.gameObject.tag == "Player")
        {
            PlayerController pController = col.gameObject.GetComponent<PlayerController>();
            pController._isOutOfArena = true;
            Debug.Log("Player Exit");
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
