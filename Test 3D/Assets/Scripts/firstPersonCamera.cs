using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPersonCamera : MonoBehaviour
{
    Camera cam;

    public float mouseX;
    public float mouseY;

    float sensitivity = 600f;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX); // It's as simple as this, it seems.

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // We add it this way instead of just changing the rotation because we want to add the clamping.

        // This currently isn't working, I need to look up how to do a first person camera. I'm doing something wrong here, and I think it has to do with clamping, but that's as far as I know.
        
    }
}
