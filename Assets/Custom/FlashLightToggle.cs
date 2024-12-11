using UnityEngine;
using UnityEngine.XR;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashlight; // Assign the flashlight Light component here

    private bool isFlashlightOn = false;
    private bool triggerPressedLastFrame = false;

    void Update()
    {
        // Get the input device for the right-hand controller
        InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        // Check if the trigger button is pressed
        if (rightHand.TryGetFeatureValue(CommonUsages.triggerButton, out bool isTriggerPressed))
        {
            // Toggle only on the button press, not when holding
            if (isTriggerPressed && !triggerPressedLastFrame)
            {
                ToggleFlashlight();
            }

            // Update the state for the next frame
            triggerPressedLastFrame = isTriggerPressed;
        }
    }

    private void ToggleFlashlight()
    {
        isFlashlightOn = !isFlashlightOn;
        flashlight.enabled = isFlashlightOn;
    }
}