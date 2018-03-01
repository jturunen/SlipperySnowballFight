using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player2Controller : MonoBehaviour
{
    Quaternion initRot;
    Slider _slider = null;
    public float _hp = 1.0f;
    public bool _isOutOfArena = false;

    public float projectileVelocity;

    private int currentChargingState = -1;
    public float chargingTime;
    public float nextChargingTime;
    Animator animator;

    public float moveSpeed;
    public float slipfactor;
    private Rigidbody myRigidBody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;
    public SpriteRenderer playerSprite;

    public GunController theGun;

    public bool useController;

    private bool facingRight = false;
    // Use this for initialization
    void Start()
    {
        nextChargingTime = chargingTime;
        initRot = transform.rotation;

        //Change player1HP name with the slider names
        _slider = GameObject.Find("player2HP").GetComponent<Slider>();

        myRigidBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        animator = playerSprite.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        moveInput = new Vector3(Input.GetAxisRaw("P2_Horizontal"), 0f, Input.GetAxisRaw("P2_Vertical"));
        moveVelocity = moveInput * moveSpeed;

        if (moveInput.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput.x < 0 && facingRight)
        {
            Flip();
        }

        if (moveInput.x < 0 && moveInput.z > 0)
        {
            animator.ResetTrigger("WalkUpSide");
            animator.SetTrigger("WalkUpSide");
        }
        if (moveInput.x == -1 && moveInput.z == 0)
        {

            animator.ResetTrigger("WalkLeft");
            animator.SetTrigger("WalkLeft");
        }
        if (moveInput.x < 0 && moveInput.z < 0)
        {
            Flip();

            animator.ResetTrigger("WalkDownSide");
            animator.SetTrigger("WalkDownSide");
        }
        if (moveInput.x == 0 && moveInput.z == -1)
        {

            animator.ResetTrigger("WalkUp");
            animator.SetTrigger("WalkDown");
        }
        if (moveInput.x > 0 && moveInput.z < 0)
        {
            Flip();

            animator.ResetTrigger("WalkDownSide");
            animator.SetTrigger("WalkDownSide");
        }
        if (moveInput.x == 1 && moveInput.z == 0)
        {

            animator.ResetTrigger("WalkLeft");
            animator.SetTrigger("WalkLeft");
        }
        if (moveInput.x > 0 && moveInput.z > 0)
        {

            animator.ResetTrigger("WalkUpSide");
            animator.SetTrigger("WalkUpSide");
        }
        if (moveInput.x == 0 && moveInput.z == 1)
        {

            animator.ResetTrigger("WalkDown");
            animator.SetTrigger("WalkUp");
        }

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
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("P2_RHorizontal") + Vector3.forward * -Input.GetAxisRaw("P2_RVertical");
            if (playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }

            if (Input.GetButton("P2_Fire1"))
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
                    Debug.Log("Player 2 charge: " + currentChargingState);
                }
            }
            if (Input.GetButtonUp("P2_Fire1"))
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
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void RemovePlayer()
    {
        gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        playerSprite.transform.rotation = initRot;
    }
}
