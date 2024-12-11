using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light[] lights; // Array of lights to toggle

    private bool areLightsOn = true; // Track the current state of the lights

    // Method to toggle all lights on/off
    public void ToggleLights()
    {
        areLightsOn = !areLightsOn; // Toggle the state

        // Iterate through each light and change its state
        foreach (var light in lights)
        {
            if (light != null)
            {
                light.enabled = areLightsOn; // Set the light's enabled state
            }
        }
    }
}