using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaTriggerController : MonoBehaviour {

    PlayerController referenceScript;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger exit!");

        // To find the GameObject with tag "ObjectOne" you would use:
        if (other.gameObject.tag == "Player")
        {
            // this method searches the scene for object, which is tagged "ObjectOne" and
            // assigns it to the 'referenceObject' variable
            // Now you need to get the component called 'ScriptOne' that's attached to the object.
            referenceScript = other.GetComponent<PlayerController>();
            // you call GetComponent <ComponentType>() on the referenceObject and it returns
            // the component of the type that you specified between < > (if it has one).
            // Now you can change the variable inside the ObjectOne, from the inside of ObjectTwo
            referenceScript.doDmg = true;
            // You can launch a method that's defined in 'ScriptOne' as well
            //referenceScript.MethodToCall();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Has Entered");
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("...");
        }
    }

}
