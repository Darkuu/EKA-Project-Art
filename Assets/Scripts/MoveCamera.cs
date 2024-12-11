using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 2f; 
    [SerializeField] private float movementSpeed = 1f; 
    [SerializeField] private float verticalRotationLimit = 80f;
    [SerializeField] private GameObject camera;
    

    private float rotationX = 0f;  
    private float rotationY = 0f;  

    void Update()
    {
        RotateCamera();
        CameraMovement();
    }

    private void RotateCamera()
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

    private void CameraMovement()
    {
        // Side to side movement
        float InputX = Input.GetAxis("Vertical");   // Forward-backward movement
        float InputZ = Input.GetAxis("Horizontal"); // Left-right movement
        
        // Up and Down movement
        float verticalInput = 0;
        if (Input.GetKey(KeyCode.LeftShift)) verticalInput += 1f;
        if (Input.GetKey(KeyCode.LeftControl)) verticalInput -= 1f;
        
        // Get the camera's forward and right directions
        Vector3 forward = Camera.main.transform.forward; // Camera's forward direction
        Vector3 right = Camera.main.transform.right;     // Camera's right direction
        
        forward.y = 0;
        right.y = 0;
        

    
        forward.Normalize();
        right.Normalize();
        right.Normalize();

        // Calculate movement direction relative to the camera
        Vector3 movement = forward * InputX + right * InputZ;
        Vector3 verticalMovement = Vector3.up * verticalInput;

        // Move the object
        Vector3 combinedMovement = movement + verticalMovement;
        transform.Translate(combinedMovement * movementSpeed * Time.deltaTime, Space.World);


    }

}