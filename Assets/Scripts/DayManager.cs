using UnityEngine;
using UnityEngine.Events;
using TMPro; // Import TextMeshPro namespace

public class DayManager : MonoBehaviour
{
    public static DayManager instance;

    public UnityEvent OnNewDay;

    [Header("Valid Color Settings")] public string currentValidColor; // Store the valid color as a string
    public TextMeshProUGUI validColorText; // Reference to the TextMeshProUGUI component

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // Initialize the current valid color and update the display
            currentValidColor = GetRandomValidColor();
            UpdateValidColorDisplay();
        }
        else
        {
        }
    }

    public void ChangeDay()
    {
        // Logic to change day and set valid color
        currentValidColor = GetRandomValidColor();

        // Update the display text
        UpdateValidColorDisplay();

        // Invoke OnNewDay event
        OnNewDay.Invoke();
    }

    public string GetCurrentValidColorString()
    {
        return currentValidColor; // Return the valid color as a string
    }

    private string GetRandomValidColor()
    {
        // Implement your logic to set a valid color for the day
        string[] validColors = { "red","green"};
        return validColors[Random.Range(0, validColors.Length)];
    }

    private void UpdateValidColorDisplay()
    {
        if (validColorText != null)
        {
            // Update the TextMeshProUGUI component with the current valid color
            validColorText.text =
                $"Today's Paintings must be mainly made of the color <color={currentValidColor}>{currentValidColor.ToUpper()}</color>";
        }
        else
        {
            Debug.LogWarning("ValidColorText is not assigned in the DayManager!");
        }
    }
}