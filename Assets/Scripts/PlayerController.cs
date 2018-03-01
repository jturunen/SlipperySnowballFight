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

        if(moveInput.x < 1 && moveInput.x > 0.7f)
        {
            Debug.Log("Up");
        } else if(moveInput.x < 0.6f && moveInput.x > 0.3f)
        {
            Debug.Log("LeftUp");
        } else if (moveInput.x < 0.2f && moveInput.x > -0.2f)
        {
            Debug.Log("Left");
        }
        else if (moveInput.x < -0.3f && moveInput.x > -0.6f)
        {
            Debug.Log("LeftDown");
        } else if (moveInput.x < -0.7f && moveInput.x > -1f)
        {
            Debug.Log("Down");
        }


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
