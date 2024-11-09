using UnityEngine;

public class FinalSubmissionZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Artwork artwork = other.GetComponent<Artwork>();
        if (artwork != null && artwork.isGraded) 
        {
            SubmitArtwork(artwork);
        }
    }

    private void SubmitArtwork(Artwork artwork)
    {
        Debug.Log("Artwork successfully submitted!");
        
        // Optional: Reward player or give feedback for successful submission
        Destroy(artwork.gameObject); // Remove artwork after submission
    }
}