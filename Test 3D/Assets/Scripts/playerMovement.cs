using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 5f;
    float inpX;
    float inpZ;

    Vector3 movement;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        inpX = Input.GetAxisRaw("Horizontal");
        inpZ = Input.GetAxisRaw("Vertical");

        // movement = new Vector3 (inpX * speed, currentVelocity, inpZ * speed);
        movement = (transform.right * inpX * speed) + (transform.forward * inpZ * speed); // We do it this way because we want our player to move forward in the direction we are facing.
        characterController.Move(movement * Time.deltaTime);

    }

}
