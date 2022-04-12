using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGravity : generalGravity
{
    public playerGravity()
    {
        jumpForce = 10f;
        currentVelocity = 0f;

    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    private void Update()
    {
        isGrounded = CheckForGround(groundCheck, groundMask);

        currentVelocity = SetVelocity(isGrounded, currentVelocity);

        ApplyGravity(characterController, currentVelocity);

    }



}
