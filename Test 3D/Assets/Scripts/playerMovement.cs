using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameObject groundCheck;
    public LayerMask groundMask;

    CharacterController characterController;

    public float speed = 5f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public float currentVelocity = 0f;
    
    float inpX;
    float inpZ;

    bool isGrounded;

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
        
        isGrounded = CheckForGround(groundCheck, groundMask);

        if (isGrounded)
        {
            currentVelocity = 0f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentVelocity += jumpForce;
                print("Jumping!");
            }

        } else
        {
            currentVelocity += gravity * Time.deltaTime;
        }

        // movement = new Vector3 (inpX * speed, currentVelocity, inpZ * speed);
        movement = (transform.right * inpX * speed) + (transform.up * currentVelocity) + (transform.forward * inpZ * speed); // We do it this way because we want our player to move forward in the direction we are facing.
        characterController.Move(movement * Time.deltaTime);

    }

    bool CheckForGround(GameObject groundCheck, LayerMask groundMask)
    {
        bool result = Physics.Raycast(groundCheck.transform.position, Vector3.down, 0.1f, groundMask);
        return result;
    }
}
