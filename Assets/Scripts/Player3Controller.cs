using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player3Controller : MonoBehaviour
{

    Slider _slider = null;
    float _hp = 1.0f;
    public bool _isOutOfArena = false;

    public float projectileVelocity;

    private int currentChargingState = -1;
    public float chargingTime;
    public float nextChargingTime;

    public float moveSpeed;
    public float slipfactor;
    private Rigidbody myRigidBody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunController theGun;

    public bool useController;

    // Use this for initialization
    void Start()
    {
        nextChargingTime = chargingTime;

        //Change player1HP name with the slider names
        _slider = GameObject.Find("player3HP").GetComponent<Slider>();

        myRigidBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        moveInput = new Vector3(Input.GetAxisRaw("P3_Horizontal"), 0f, Input.GetAxisRaw("P3_Vertical"));
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
                    Debug.Log("Player 3 charge: " + currentChargingState);
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
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("P3_RHorizontal") + Vector3.forward * -Input.GetAxisRaw("P3_RVertical");
            if (playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }

            if (Input.GetButton("P3_Fire1"))
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
                    Debug.Log("Player 3 charge: " + currentChargingState);
                }
            }
            if (Input.GetButtonUp("P3_Fire1"))
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
                RemovePlayer();
                _hp = 0;
            }
        }
        _slider.value = _hp;
    }

    private void FixedUpdate()
    {
        myRigidBody.velocity += moveVelocity / slipfactor;

    }

    private void RemovePlayer()
    {
        gameObject.SetActive(false);
    }
}
