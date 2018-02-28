using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public float projectileHitForce;
    public float projectileDamage;

    private Rigidbody rigidbody;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        //all projectile colliding game objects should be tagged "Player" or whatever in inspector but that tag must be reflected in the below if conditional
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("HIT!");
            rigidbody = collider.gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(transform.forward * projectileHitForce);
            //destroy the projectile
            Destroy(gameObject);
        }
    }
}
