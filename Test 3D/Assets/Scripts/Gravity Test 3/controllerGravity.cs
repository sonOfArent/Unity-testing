using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerGravity : MonoBehaviour
{
    public float SetVelocity(float currentVelocity, GameObject groundCheck, LayerMask groundMask, float gravity = -9.81f, bool isJumping = false, float jumpForce = 0f)
    {
        bool isGrounded = Physics.Raycast(groundCheck.transform.position, Vector3.down, 0.1f, groundMask);

        if (isGrounded && isJumping)
        {
            currentVelocity += jumpForce;

        }
        else if (isGrounded)
        {
            currentVelocity = -0.1f;

        }
        else
        {
            currentVelocity += gravity * Time.deltaTime;
        }

        return currentVelocity;

    }

    public bool CheckForGround(GameObject groundCheck, LayerMask groundMask)
    {
        bool result = Physics.Raycast(groundCheck.transform.position, Vector3.down, 0.1f, groundMask);
        return result;
    }

}
