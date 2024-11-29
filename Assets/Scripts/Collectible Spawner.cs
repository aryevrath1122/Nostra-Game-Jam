using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    
    public GameObject CollectiblePrefab;  // The collectible prefab to spawn
    public float spawnInterval = 2f;      // Time interval between spawns
    public float spawnRangeX = 3f;        // Horizontal range where collectibles can spawn
    public float spawnRangeY = 3f;        // Vertical range where collectibles can spawn
    public Transform spawnPosition;
    
    Collectible c;
    void Start()
    {
        
        InvokeRepeating("SpawnCollectible", 0f, spawnInterval);
    }

    void SpawnCollectible()
    {


        // Instantiate the obstacle at the spawn position
        Instantiate(CollectiblePrefab, spawnPosition.position, Quaternion.identity);
    }
}
