using System.Collections;
using UnityEngine;

public class ArtworkSpawner : MonoBehaviour
{
    public GameObject[] artworkPrefabs;   
    public Transform spawnLocation;       
    public Vector2 spawnDelayRange = new Vector2(5f, 10f);

    private bool isSpawning = false;

    private void OnMouseDown()
    {
        // Check if an artwork is already in the process of spawning
        if (!isSpawning)
        {
            StartCoroutine(SpawnArtworkWithDelay());
            Debug.Log("Clicked!");
        }
    }

    private IEnumerator SpawnArtworkWithDelay()
    {
        Debug.Log("Clicked!");
        isSpawning = true; // Prevent multiple spawns at once

        // Get a random delay between minDelay and maxDelay
        float delay = Random.Range(spawnDelayRange.x, spawnDelayRange.y);
        yield return new WaitForSeconds(delay);

        // Choose a random artwork from the array
        GameObject selectedArtwork = artworkPrefabs[Random.Range(0, artworkPrefabs.Length)];

        // Spawn the selected artwork at the specified location
        Instantiate(selectedArtwork, spawnLocation.position, Quaternion.identity);

        isSpawning = false; // Allow spawning again
    }
}