using UnityEngine;
using System.Collections;

public class RandomObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Vector2 xRange = new Vector2(-6f, 6f);
    public Vector2 yRange = new Vector2(-3f, 3f);

    private GameObject currentObstacle;

    void Start()
    {
        StartCoroutine(SpawnRandomObstacle());
    }

    IEnumerator SpawnRandomObstacle()
    {
        while (true)
        {
            // Destroy the existing obstacle
            if (currentObstacle != null)
            {
                Destroy(currentObstacle);
            }

            // Randomly select a prefab
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);

            // Random position with Z clamped to 0
            Vector3 randomPosition = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 0);

            // Set the rotation to X=90, Y=90, Z=0
            Quaternion alignedRotation = Quaternion.Euler(90f, 90f, 0f);

            // Instantiate the obstacle with the specified rotation and position
            currentObstacle = Instantiate(obstaclePrefabs[randomIndex], randomPosition, alignedRotation);

            // Ensure the obstacle stays on Z = 0
            currentObstacle.transform.position = new Vector3(currentObstacle.transform.position.x, currentObstacle.transform.position.y, 0);

            // Wait for 10 seconds before spawning a new obstacle
            yield return new WaitForSeconds(10);
        }
    }
}

