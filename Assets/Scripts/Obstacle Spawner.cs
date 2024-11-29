using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;   // The obstacle prefab to spawn
    public float spawnInterval = 2f;    // Time interval between spawns
    public float spawnRangeX = 8f;      // Horizontal range where obstacles can spawn
    public float spawnRangeY = 4f;      // Vertical range where obstacles can spawn
    public Transform spawnPosition;

    void Start()
    {
        // Start spawning obstacles at regular intervals
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }

    void SpawnObstacle()
    {
        

        // Instantiate the obstacle at the spawn position
        Instantiate(obstaclePrefab, spawnPosition.position, Quaternion.identity);
    }
 
}
