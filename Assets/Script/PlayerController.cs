using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public GameObject projectilePrefab;
    public Transform projectileSpawn;

    public float projectileVelocity;

    AudioSource audio;
    public AudioClip audioClipProjectile;


    // Use this for initialization
    void Start () {
        audio = gameObject.AddComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
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

        // Add velocity to the bullet
        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * projectileVelocity;

        // Destroy the bullet after 10 seconds
        Destroy(projectile, 10.0f);
    }
}
