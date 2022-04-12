using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
    CharacterController characterController;

    public float gravity = -9.81f;

    float currentVelocity = 0f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        AddGravity(characterController);'sx
    }sxsxsxsxsxx


    // Update is called once per frame
    void Update()
    {
        
    }

    void AddGravity(CharacterController controller)
    {
        controller.Move(transform.up * currentVelocity);
    }

}
