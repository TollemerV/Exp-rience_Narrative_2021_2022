﻿using UnityEngine;

public class Movement : MonoBehaviour
{
    public Camera playerCamera;
    CharacterController characterController;
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 15f;
//  public float jumpSpeed = 8f;
    Vector3 moveDirection;
    float gravity = 20f;
    private bool isRunning;

    float rotationX = 0;
    public float rotationSpeed = 2.0f;
    public float rotationXLimit = 45.0f;

    public bool isPause = false;
    public GameObject pauseMenu;

    public GameObject inventory;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked ;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!isPause)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            float speedZ = Input.GetAxis("Vertical");
            float speedX = Input.GetAxis("Horizontal");
            float speedY = moveDirection.y;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }

            if (isRunning)
            {
                speedX *= runningSpeed;
                speedZ *= runningSpeed;
            }
            else
            {
                speedX *= walkingSpeed;
                speedZ *= walkingSpeed;
            }

            moveDirection = forward * speedZ + right * speedX;

            /*if (Input.GetButton("Jump") && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                
            }*/
            moveDirection.y = speedY;
            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * 15 * Time.deltaTime;
            }


            characterController.Move(moveDirection * Time.deltaTime);

            if (Input.GetKey(KeyCode.Escape))
            {
                isPause = true;
                Cursor.visible = true;
                Cursor.lockState = 0;
                pauseMenu.SetActive(true);
            }
            if (Input.GetKey(KeyCode.I))
            {
                StartCoroutine(Second());
                System.Collections.IEnumerator Second()
                {
                    yield return new WaitForSeconds(0.2f);
                    isPause = true;
                    Cursor.visible = true;
                    Cursor.lockState = 0;
                    inventory.SetActive(true);
                } 
            }

            

            rotationX += -Input.GetAxis("Mouse Y") * rotationSpeed;
            rotationX = Mathf.Clamp(rotationX, -rotationXLimit, rotationXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX,0,0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
        }
        
        
    }
    
}
