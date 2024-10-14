using UnityEngine;

public class MovingPowerUp : MonoBehaviour
{
    public float moveSpeed = 2f;    // Speed of the vertical movement
    public float moveRange = 3f;    // Distance the capsule will move up and down

    private Vector3 startPosition;

    void Start()
    {
       
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveRange;

        
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
