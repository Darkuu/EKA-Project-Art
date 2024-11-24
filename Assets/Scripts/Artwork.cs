using UnityEngine;

public class Artwork : MonoBehaviour
{
    [Header("User Defined Properties")]
    public string colorName;
    public string style;
    public bool isValid;

    public bool isGraded = false; // Track if artwork has been graded
    public bool wasGradedCorrectly = false; // Track if artwork was graded correctly

    void Start()
    {
        DayManager.instance.OnNewDay.AddListener(CheckValidity);
        CheckValidity();
    }

    public void CheckValidity()
    {
        isValid = DetermineValidity();
    }

    private bool DetermineValidity()
    {
        string currentValidColor = DayManager.instance.GetCurrentValidColorString();
        return colorName.Equals(currentValidColor, System.StringComparison.OrdinalIgnoreCase);
    }

    private void OnDestroy()
    {
        if (DayManager.instance != null)
            DayManager.instance.OnNewDay.RemoveListener(CheckValidity);
    }
}
