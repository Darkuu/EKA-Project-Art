using UnityEngine;

public class DropZone : MonoBehaviour
{
    public enum Rating { Yes, No }
    public Rating ratingType;

    private void OnTriggerEnter(Collider other)
    {
        Artwork artwork = other.GetComponent<Artwork>();
        EvaluateArtwork(artwork);
    }

    private void EvaluateArtwork(Artwork artwork)
    {
        bool isCorrect = (ratingType == Rating.Yes && artwork.isValid) || 
                         (ratingType == Rating.No && !artwork.isValid);

        if (isCorrect)
        {
            Debug.Log("Correct rating!");
        }
        else
        {
            Debug.Log("Incorrect rating.");
        }

        artwork.isGraded = true; // Mark as graded
        Debug.Log("Please submit the graded artwork to the final submission zone.");
    }
}