using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public float projectileHitForce;
    public float projectileDamage;

    private new Rigidbody rigidbody;

    public int currentProjectileStage;
    

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < currentProjectileStage; i++)
        {
            transform.localScale += new Vector3(0.5F, 0.5F, 0.5F);
        }
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

            if (currentProjectileStage >= 3)
            {
                rigidbody.AddForce(transform.up * projectileHitForce * 4f);
            }
            else if (currentProjectileStage <= 3 && currentProjectileStage >= 2)
            {
                rigidbody.AddForce(transform.up * (projectileHitForce * 3f));
            }
            else if (currentProjectileStage <= 2 && currentProjectileStage >= 1)
            {
                rigidbody.AddForce(transform.up * (projectileHitForce * 2f));
            }
            else if (currentProjectileStage <= 1)
            {
                rigidbody.AddForce(transform.up * (projectileHitForce));
            }

            //destroy the projectile
            Destroy(gameObject);
        }
    }
}
