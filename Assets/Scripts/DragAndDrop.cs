using UnityEngine;

public class Drag3DObject : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask draggableLayer;
    [SerializeField] private float dragDepth = 2.6f; // Distance from camera when dragging

    private bool isDragging = false;
    private Vector3 offset;

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;  // Reference to the main camera
    }

    private void OnMouseDown()
    {
        // Check if the object is on the correct layer before dragging
        if (((1 << gameObject.layer) & draggableLayer) != 0)
        {
            // Calculate the offset between the object position and the mouse in world space
            offset = transform.position - GetMouseWorldPosition();
            isDragging = true;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false; // Release the drag
    }

    private void Update()
    {
        if (isDragging)
        {
            // Update position based on the mouse with offset
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    // Helper function to get mouse position in world space
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = dragDepth; // Set a fixed depth for consistent dragging
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}