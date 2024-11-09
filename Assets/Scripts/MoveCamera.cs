using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 2f;  
    [SerializeField] private float verticalRotationLimit = 80f;  

    private float rotationX = 0f;  
    private float rotationY = 0f;  

    void Update()
    {
        // Get the mouse input for movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Only rotate the camera if the right mouse button is held down
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked; 
            // Update the rotation values
            rotationX += mouseX; 
            rotationY -= mouseY; 

            // Clamp vertical rotation to avoid flipping
            rotationY = Mathf.Clamp(rotationY, -verticalRotationLimit, verticalRotationLimit);

            // Apply the rotations to the camera
            transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0f);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}