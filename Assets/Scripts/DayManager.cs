using UnityEngine;
using UnityEngine.Events;

public class DayManager : MonoBehaviour
{
    public static DayManager instance;

    public UnityEvent OnNewDay;

    public string currentValidColor; // Store the valid color as a string

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeDay()
    {
        // Logic to change day and set valid color
        // Example: Let's say today's valid color is determined by some logic
        currentValidColor = GetRandomValidColor();
        OnNewDay.Invoke();
    }

    public string GetCurrentValidColorString()
    {
        return currentValidColor; // Return the valid color as a string
    }

    private string GetRandomValidColor()
    {
        // Implement your logic to set a valid color for the day
        string[] validColors = { "red", "blue", "green", "purplepink", "brightgreen" }; // Add custom colors
        return validColors[Random.Range(0, validColors.Length)];
    }
}