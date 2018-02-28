using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public GameObject projectilePrefab;
    public Transform projectileSpawn;

    public float projectileVelocity;
    
    private int currentChargingState = -1;
    public float chargingTime;
    public float nextChargingTime;

    AudioSource audio;
    public AudioClip audioClipProjectile;


    // Use this for initialization
    void Start () {
        audio = gameObject.AddComponent<AudioSource>();
        nextChargingTime = chargingTime;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time > nextChargingTime)
            {
                nextChargingTime += chargingTime;

                if (currentChargingState >= 4)
                {
                    currentChargingState = 4;
                } else
                {
                    currentChargingState += 1;
                }
                Debug.Log("STATE: " + currentChargingState);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Fire();
            currentChargingState = -1;
        }
    }

    void Fire()
    {
        audio.PlayOneShot(audioClipProjectile);

        // Create the Bullet from the Bullet Prefab
        var projectile = (GameObject)Instantiate(
            projectilePrefab,
            projectileSpawn.position,
            projectileSpawn.rotation);
        projectile.GetComponent<ProjectileController>().currentProjectileStage = currentChargingState;

        // Add velocity to the bullet
        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * projectileVelocity;

        // Destroy the bullet after 10 seconds
        Destroy(projectile, 10.0f);
    }
}
