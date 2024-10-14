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
            
            if (currentObstacle != null)
            {
                Destroy(currentObstacle);
            }

           
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);

            
            Vector3 randomPosition = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 0);

          
            Quaternion alignedRotation = Quaternion.Euler(90f, 90f, 0f);

            
            currentObstacle = Instantiate(obstaclePrefabs[randomIndex], randomPosition, alignedRotation);

           
            currentObstacle.transform.position = new Vector3(currentObstacle.transform.position.x, currentObstacle.transform.position.y, 0);

           
            yield return new WaitForSeconds(10);
        }
    }
}

