using UnityEngine;

public class FinalSubmissionZone : MonoBehaviour
{
    [SerializeField] private float artworkValue = 100f;  
    public MoneyManager moneyManager;  

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
        // Reward money if the artwork was graded correctly
        if (artwork.wasGradedCorrectly) 
        {
            moneyManager.AddMoney(artworkValue); 
        }

        Destroy(artwork.gameObject); // Remove artwork from the scene
    }
}