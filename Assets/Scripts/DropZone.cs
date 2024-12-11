using UnityEngine;

public class DropZone : MonoBehaviour
{
    public enum Rating { Yes, No }
    public Rating ratingType;

    private void OnTriggerEnter(Collider other)
    {
        Artwork artwork = other.GetComponent<Artwork>();
        if (artwork != null)
        {
            EvaluateArtwork(artwork);
        }
    }

    private void EvaluateArtwork(Artwork artwork)
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