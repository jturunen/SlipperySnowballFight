﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour {
    Quaternion initRot;
 
    Slider _slider = null;
    float _hp = 1.0f;
    public bool _isOutOfArena = false;

    public float projectileVelocity;
    
    private int currentChargingState = -1;
    public float chargingTime;
    public float nextChargingTime;

    public float moveSpeed;
    private Rigidbody myRigidBody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public SpriteRenderer reindeerSprite;
    public Quaternion reindeerRotation;

    public GunController theGun;

    public bool useController;

    // Use this for initialization
    void Start () {
        initRot = transform.rotation;

        nextChargingTime = chargingTime;

        //Change player1HP name with the slider names
        _slider = GameObject.Find("player1HP").GetComponent<Slider>();

        myRigidBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }
	
	// Update is called once per frame
	void Update () {

        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        moveVelocity = moveInput * moveSpeed;

        //Rotate with mouse
        if (!useController)
        {

            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }

            if (Input.GetMouseButton(0))
            {
                if (Time.time > nextChargingTime)
                {
                    nextChargingTime += chargingTime;

                    if (currentChargingState >= 4)
                    {
                        currentChargingState = 4;
                    }
                    else
                    {
                        currentChargingState += 1;
                    }
                    Debug.Log("STATE: " + currentChargingState);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                theGun.Fire(currentChargingState);

                currentChargingState = -1;
            }
        }

        //Rotate with Controller
        if (useController)
        {
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * -Input.GetAxisRaw("RVertical");
            if (playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }

            reindeerRotation.eulerAngles = transform.rotation.eulerAngles;

            if (reindeerRotation.eulerAngles.y >= 0 && reindeerRotation.eulerAngles.y < 30)
            {
                Debug.Log("UP");
            
            }
            else if (reindeerRotation.eulerAngles.y > 30 && reindeerRotation.eulerAngles.y < 60)
            {
                Debug.Log("UP-RIGHT");

            }
            else if (reindeerRotation.eulerAngles.y > 60 && reindeerRotation.eulerAngles.y < 120)
            {
                Debug.Log("RIGHT");

            }
            else if (reindeerRotation.eulerAngles.y > 120 && reindeerRotation.eulerAngles.y < 150)
            {
                Debug.Log("DOWN-RIGHT");

            }
            else if (reindeerRotation.eulerAngles.y > 150 && reindeerRotation.eulerAngles.y < 210)
            {
                Debug.Log("DOWN");

            }
            else if (reindeerRotation.eulerAngles.y > 210 && reindeerRotation.eulerAngles.y < 240)
            {
                Debug.Log("DOWN-LEFT");

            }
            else if (reindeerRotation.eulerAngles.y > 240 && reindeerRotation.eulerAngles.y < 300)
            {
                Debug.Log("LEFT");

            }
            else if (reindeerRotation.eulerAngles.y > 300 && reindeerRotation.eulerAngles.y < 360)
            {
                Debug.Log("UP-LEFT");

            }



            if (Input.GetKey(KeyCode.Joystick1Button5))
            {
                if (Time.time > nextChargingTime)
                {
                    nextChargingTime += chargingTime;

                    if (currentChargingState >= 4)
                    {
                        currentChargingState = 4;
                    }
                    else
                    {
                        currentChargingState += 1;
                    }
                    Debug.Log("STATE: " + currentChargingState);
                }
            }
            if (Input.GetKeyUp(KeyCode.Joystick1Button5))
            {
                theGun.Fire(currentChargingState);

                currentChargingState = -1;
            }

        }

        if (_isOutOfArena)
        {
            _hp -= 0.01f;
            if (_hp < 0)
            {
                _hp = 0;
            }
        }
        _slider.value = _hp;
    }

    private void LateUpdate()
    {
        reindeerSprite.transform.rotation = initRot;
    }

    private void FixedUpdate()
    {
        myRigidBody.velocity = moveVelocity;
    }
}
