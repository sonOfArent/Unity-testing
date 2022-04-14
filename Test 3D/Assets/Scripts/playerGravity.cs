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

}
