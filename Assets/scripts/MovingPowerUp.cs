using UnityEngine;

public class MovingPowerUp : MonoBehaviour
{
    public float moveSpeed = 2f;    // Speed of the vertical movement
    public float moveRange = 3f;    // Distance the capsule will move up and down

    private Vector3 startPosition;

    void Start()
    {
        // Store the starting position of the capsule
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position using a sinusoidal pattern for smooth movement
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveRange;

        // Apply the new Y position while keeping the X and Z positions the same
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
