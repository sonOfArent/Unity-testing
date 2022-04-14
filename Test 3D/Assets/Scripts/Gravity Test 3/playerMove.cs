using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public CharacterController characterController;
    public GameObject groundCheck;
    public LayerMask groundMask;
    public controllerGravity cont;

    public float speed = 5f;
    public float jumpForce = 10f;
    public float currentVelocity = 0f;
    public float gravity = -9.81f;
    float inpX;
    float inpZ;

    bool isJumping;

    Vector3 movement;
    Vector3 y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inpX = Input.GetAxisRaw("Horizontal");
        inpZ = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space)) {
            isJumping = true;
        }

        currentVelocity = cont.SetVelocity(currentVelocity, groundCheck, groundMask, gravity, isJumping);

        y = transform.up * currentVelocity;

        // movement = new Vector3 (inpX * speed, currentVelocity, inpZ * speed);
        movement = (transform.right * inpX * speed) + y + (transform.forward * inpZ * speed); // We do it this way because we want our player to move forward in the direction we are facing.
        characterController.Move(movement * Time.deltaTime);

        if (isJumping)
        {
            isJumping = false;
        }
    }

}
