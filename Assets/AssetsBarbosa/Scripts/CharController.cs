using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    private Transform playerPosition;
    public Transform respawnPoint;

    CharacterController characterController;
    [HideInInspector]
    public Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        playerPosition = GameObject.Find("Player").transform;
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;

        playerPosition.position = respawnPoint.position;
    }

    void Update()
    {
        
        //transform.position = respawnPoint.transform.position;
        if(playerPosition.position.y < 20f)
        {
            playerPosition.position = respawnPoint.position;
        }
        else
        {
           // Debug.Log(playerPosition.position);

            if (characterController.isGrounded)
            {
                // We are grounded, so recalculate move direction based on axes
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);
                float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
                float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);

                /*if (Input.GetButton("Jump") && canMove)
                {
                    moveDirection.y = jumpSpeed;
                }*/
            }

            // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
            // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
            // as an acceleration (ms^-2)
            moveDirection.y -= gravity * Time.deltaTime;

            // Move the controller
            characterController.Move(moveDirection * Time.deltaTime);

            // Player and Camera rotation
            if (canMove)
            {
                rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
                rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
                transform.eulerAngles = new Vector2(0, rotation.y);
            }
        }
        
    }
}