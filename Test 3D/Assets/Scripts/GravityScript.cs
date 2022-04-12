using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
    public GameObject groundCheck;
    public LayerMask groundMask;
    
    CharacterController characterController;

    public float gravity = -9.81f;
    public float jumpForce = 5f; 
    public float currentVelocity = 0f;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    void FixedUpdate()
    {
        isGrounded = CheckForGround(groundCheck, groundMask);

        if (isGrounded)
        {
            currentVelocity = 0f;

        }
        else
        {
            currentVelocity += gravity * Time.deltaTime;
        }

        AddGravity(characterController);

    }

    public bool CheckForGround(GameObject groundCheck, LayerMask groundMask)
    {
        bool result = Physics.Raycast(groundCheck.transform.position, Vector3.down, 0.1f, groundMask);
        return result;
    }

    public void AddGravity(CharacterController characterController)
    {
        characterController.Move(transform.up * currentVelocity * Time.deltaTime);
    }

    public void Jump(float jumpForce)
    {
        currentVelocity += jumpForce;
    }



}
