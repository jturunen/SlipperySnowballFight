using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public bool isFiring;

    public GameObject projectilePrefab;
    public float projectileVelocity;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform projectileSpawn;

    new AudioSource audio;
    public AudioClip audioClipProjectile;

    // Use this for initialization
    void Start () {
        audio = gameObject.AddComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void Fire(int currentChargingState)
    {
        audio.PlayOneShot(audioClipProjectile);

        // Create the Bullet from the Bullet Prefab
        var projectile = (GameObject)Instantiate(
            projectilePrefab,
            projectileSpawn.position,
            projectileSpawn.rotation);
        projectile.GetComponent<ProjectileController>().currentProjectileStage = currentChargingState;

        // Add velocity to the bullet
        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.up * projectileVelocity;

        // Destroy the bullet after 10 seconds
        Destroy(projectile, 10.0f);
    }
}
