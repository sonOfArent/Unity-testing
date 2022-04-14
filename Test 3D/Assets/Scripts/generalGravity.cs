using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalGravity : MonoBehaviour
{
    public CharacterController characterController;
    public GameObject groundCheck;
    public LayerMask groundMask;

    public float gravity;
    public float jumpForce;
    public float currentVelocity;

    public bool isGrounded;
    public bool isJumping;

    public generalGravity()
    {
        gravity = -9.81f;
        jumpForce = 5f;
        currentVelocity = 0f;
    }

    public Vector3 ApplyGravity(CharacterController characterController, float currentVelocity)
    {
        // characterController.Move(characterController.transform.up * currentVelocity * Time.deltaTime);
        return characterController.transform.up * currentVelocity * Time.deltaTime;
    }

    public void Jump(float currentVelocity, float jumpForce)
    {
        currentVelocity += jumpForce;
    }

    public bool CheckForGround(GameObject groundCheck, LayerMask groundMask)
    {
        bool result = Physics.Raycast(groundCheck.transform.position, Vector3.down, 0.1f, groundMask);
        return result;
    }

    public float SetVelocity(bool isGrounded, float currentVelocity, bool isJumping, float jumpForce)
    {
        float newVelocity = currentVelocity;

        if (isGrounded && isJumping)
        {
            Jump(currentVelocity, jumpForce);
            print("Is jumping!");
        }
        else if (isGrounded)
        {
            newVelocity = 0f;
        }
        else
        {
            newVelocity += gravity;
        }

        return newVelocity;
    }
}
