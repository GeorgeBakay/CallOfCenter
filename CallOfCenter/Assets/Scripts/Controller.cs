using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 
[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float gravity = 10f;
    public float weight = 0.72f;
 
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
 
 
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
 
    public bool canMove = true;
 
    
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ?  Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ?  Input.GetAxis("Horizontal") : 0;

        Vector3 newMoveDirection = (forward * curSpeedX) + (right * curSpeedY);
        //newMoveDirection.Normalize();
        newMoveDirection *= isRunning ? runSpeed : walkSpeed;
        moveDirection.x = newMoveDirection.x;
        moveDirection.z = newMoveDirection.z;

        if(Input.GetKey(KeyCode.Space )&& characterController.isGrounded){
            moveDirection.y = 15f;
        }
        else if(characterController.isGrounded == false){
            moveDirection.y += - gravity * Time.deltaTime * weight;
        }
        else{
            moveDirection.y = 0;
        }
        #endregion
 
        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);
 
        if (canMove)
        {           
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
 
        #endregion
    }
}
