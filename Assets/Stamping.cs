using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamping : MonoBehaviour
{
    public enum Rating { Yes, No }
    public Rating ratingType;

    private Artwork currentArtwork; // Store the current artwork in the trigger

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has the Artwork component
        Artwork artwork = other.GetComponent<Artwork>();
        if (artwork != null)
        {
            currentArtwork = artwork; // Save reference to the artwork
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Clear the reference when the object exits the trigger
        Artwork artwork = other.GetComponent<Artwork>();
        if (artwork != null && artwork == currentArtwork)
        {
            currentArtwork = null;
        }
    }

    private void Update()
    {
        // Check if there's a valid artwork in the trigger and space bar is pressed
        if (currentArtwork != null && Input.GetKeyDown(KeyCode.Space))
        {
            GradeArtwork(currentArtwork);
        }
    }

    private void GradeArtwork(Artwork artwork)
    {
        // Determine if the grading is correct
        bool isCorrect = (ratingType == Rating.Yes && artwork.isValid) || 
                         (ratingType == Rating.No && !artwork.isValid);

        // Mark the artwork as graded and record whether the grading was correct
        artwork.isGraded = true;
        artwork.wasGradedCorrectly = isCorrect;

        // Feedback
        if (isCorrect)
        {
            Debug.Log("Correct rating!");
        }
        else
        {
            Debug.Log("Incorrect rating.");
        }
    }
}