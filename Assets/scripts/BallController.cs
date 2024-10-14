////////using UnityEngine;

////////public class BallController : MonoBehaviour
////////{
////////    public float speed = 10f;       // Starting speed of the ball
////////    public float maxSpeed = 15f;
////////    public float minSpeed = 10f;

////////    private Rigidbody rb;

////////    private void Start()
////////    {
////////        rb = GetComponent<Rigidbody>();
////////        StartBall();
////////    }

////////    private void Update()
////////    {
////////        ClampBallSpeed();

////////        // Ensure the ball's z position stays fixed at 0
////////        Vector3 position = transform.position;
////////        position.z = 0;  // Keep the ball on the Z plane
////////        transform.position = position;
////////    }

////////    public void StartBall()
////////    {
////////        float directionX = Random.Range(0, 2) == 0 ? 1 : -1;
////////        float directionY = Random.Range(0, 2) == 0 ? 1 : -1;

////////        // Start the ball with some vertical velocity to avoid purely horizontal movement
////////        Vector3 initialVelocity = new Vector3(speed * directionX, speed * directionY + Random.Range(0.5f, 1.5f), 0);
////////        rb.velocity = initialVelocity;
////////    }

////////    private void ClampBallSpeed()
////////    {
////////        float currentSpeed = rb.velocity.magnitude;

////////        // Ensure the ball's speed is not less than the minimum speed
////////        if (currentSpeed < minSpeed)
////////        {
////////            rb.velocity = rb.velocity.normalized * (minSpeed + 1f);  // Add a buffer to ensure speed doesn't drop
////////        }
////////        else if (currentSpeed > maxSpeed)
////////        {
////////            rb.velocity = rb.velocity.normalized * maxSpeed;
////////        }

////////        // Ensure the ball always has sufficient vertical velocity
////////        if (Mathf.Abs(rb.velocity.y) < 0.7f)  // Adjust this threshold for better vertical movement
////////        {
////////            rb.velocity = new Vector3(rb.velocity.x, Mathf.Sign(rb.velocity.y) * 0.7f, rb.velocity.z);
////////        }

////////        // Ensure the ball always has sufficient horizontal velocity
////////        if (Mathf.Abs(rb.velocity.x) < 0.7f)  // Ensure X-axis has enough velocity
////////        {
////////            rb.velocity = new Vector3(Mathf.Sign(rb.velocity.x) * 0.7f, rb.velocity.y, rb.velocity.z);
////////        }
////////    }


////////    private void OnCollisionEnter(Collision collision)
////////    {
////////        // Handle Paddle and Obstacle Collisions
////////        if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("Obstacle"))
////////        {
////////            HandleBallVelocity();  // Keep velocity consistent

////////            // Move ball slightly away from paddle or obstacle to prevent overlap
////////            Vector3 objectCenter = collision.gameObject.transform.position;

////////            // Calculate push-back direction
////////            Vector3 pushDirection = (transform.position - objectCenter).normalized;
////////            transform.position += pushDirection * 0.2f;  // Increase push distance to avoid stickiness
////////        }

////////        // Handle Wall Collision
////////        if (collision.gameObject.CompareTag("Wall"))
////////        {
////////            Vector3 ballVelocity = rb.velocity;

////////            // Re-correct the vertical movement if too small
////////            if (Mathf.Abs(ballVelocity.y) < 0.5f)
////////            {
////////                rb.velocity = new Vector3(ballVelocity.x, Mathf.Sign(ballVelocity.y) * 0.5f, ballVelocity.z);
////////            }
////////        }
////////    }

////////    // Keep velocity consistent
////////    private void HandleBallVelocity()
////////    {
////////        Vector3 ballVelocity = rb.velocity;

////////        // Ensure minimum speed is maintained
////////        if (ballVelocity.magnitude < minSpeed)
////////        {
////////            rb.velocity = ballVelocity.normalized * minSpeed;
////////        }

////////        // Clamp ball position to prevent it from going out of bounds
////////        Vector3 position = transform.position;
////////        position.y = Mathf.Clamp(position.y, -3.8f, 3.8f);  // Adjust bounds as per your wall position
////////        position.z = 0;  // Force the Z position to remain fixed
////////        transform.position = position;

////////        // Ensure vertical velocity is maintained
////////        if (Mathf.Abs(ballVelocity.y) < 0.5f)  // Adjust vertical threshold
////////        {
////////            rb.velocity = new Vector3(ballVelocity.x, Mathf.Sign(ballVelocity.y) * 0.5f, ballVelocity.z);
////////        }

////////        // Ensure horizontal velocity is maintained
////////        if (Mathf.Abs(ballVelocity.x) < 0.5f)
////////        {
////////            rb.velocity = new Vector3(Mathf.Sign(ballVelocity.x) * 0.5f, rb.velocity.y, ballVelocity.z);
////////        }
////////    }

////////    private void OnTriggerEnter(Collider other)
////////    {
////////        if (other.CompareTag("Goal1"))
////////        {
////////            GameManager.Instance.AddScore(2);
////////            ResetBall();
////////        }
////////        else if (other.CompareTag("Goal2"))
////////        {
////////            GameManager.Instance.AddScore(1);
////////            ResetBall();
////////        }
////////    }

////////    private void ResetBall()
////////    {
////////        transform.position = Vector3.zero;
////////        StartBall();
////////    }
////////}

////using UnityEngine;
////using System.Collections;

////public class BallController : MonoBehaviour
////{
////    public float speed = 10f;       // Starting speed of the ball
////    public float maxSpeed = 15f;    // Maximum allowed speed
////    public float minSpeed = 10f;    // Minimum allowed speed
////    private Rigidbody rb;           // Reference to the ball's Rigidbody
////    private float originalSpeed;    // Store the original speed for resetting after speed boost

////    void Start()
////    {
////        rb = GetComponent<Rigidbody>();
////        originalSpeed = speed;
////        StartBall(); // Start ball movement when the game begins
////    }

////    public void StartBall()
////    {
////        // Randomize the initial direction of the ball (either left or right, up or down)
////        float directionX = Random.Range(0, 2) == 0 ? 1 : -1;
////        float directionY = Random.Range(0, 2) == 0 ? 1 : -1;

////        // Set the ball's velocity with some vertical and horizontal component
////        Vector3 initialVelocity = new Vector3(speed * directionX, speed * directionY + Random.Range(0.5f, 1.5f), 0);
////        rb.velocity = initialVelocity;
////    }

////    private void Update()
////    {
////        ClampBallSpeed(); // Ensure the ball's speed stays within the allowed limits

////        // Ensure the ball's z position stays fixed at 0 (since it's a 2D game in a 3D space)
////        Vector3 position = transform.position;
////        position.z = 0;
////        transform.position = position;
////    }

////    // Apply a speed boost to the ball for a certain duration
////    public void ApplySpeedBoost(float multiplier, float duration)
////    {
////        StartCoroutine(SpeedBoost(multiplier, duration));
////    }

////    private IEnumerator SpeedBoost(float multiplier, float duration)
////    {
////        // Multiply the ball's velocity to apply the speed boost
////        rb.velocity *= multiplier;

////        // Wait for the duration of the speed boost effect
////        yield return new WaitForSeconds(duration);

////        // Reset the ball's speed back to the original speed after the boost ends
////        rb.velocity /= multiplier;

////        // Ensure the ball's speed stays within the allowed limits after the boost ends
////        ClampBallSpeed();
////    }

////    private void ClampBallSpeed()
////    {
////        float currentSpeed = rb.velocity.magnitude;

////        // Ensure the ball's speed is not less than the minimum speed
////        if (currentSpeed < minSpeed)
////        {
////            rb.velocity = rb.velocity.normalized * (minSpeed + 1f);  // Add a small buffer
////        }
////        // Ensure the ball's speed does not exceed the maximum speed
////        else if (currentSpeed > maxSpeed)
////        {
////            rb.velocity = rb.velocity.normalized * maxSpeed;
////        }
////    }

////    private void OnCollisionEnter(Collision collision)
////    {
////        // Handle collisions with paddles or obstacles
////        if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("Obstacle"))
////        {
////            HandleBallVelocity();
////            Vector3 objectCenter = collision.gameObject.transform.position;
////            Vector3 pushDirection = (transform.position - objectCenter).normalized;
////            transform.position += pushDirection * 0.2f;
////        }

////        // Handle Wall Collision
////        if (collision.gameObject.CompareTag("Wall"))
////        {
////            Vector3 ballVelocity = rb.velocity;

////            // Re-correct the vertical movement if too small
////            if (Mathf.Abs(ballVelocity.y) < 0.5f)
////            {
////                rb.velocity = new Vector3(ballVelocity.x, Mathf.Sign(ballVelocity.y) * 0.5f, ballVelocity.z);
////            }

////            // Ensure the ball doesn't stick to the wall by adjusting its position slightly
////            Vector3 position = transform.position;
////            position.y = Mathf.Clamp(position.y, -3.8f, 3.8f);  // Adjust based on your walls' Y-axis position
////            transform.position = position;
////        }
////    }

////    // Ensure the ball's velocity remains consistent and within the bounds of the game
////    private void HandleBallVelocity()
////    {
////        Vector3 ballVelocity = rb.velocity;

////        // Maintain minimum speed
////        if (ballVelocity.magnitude < minSpeed)
////        {
////            rb.velocity = ballVelocity.normalized * minSpeed;
////        }

////        // Clamp the ball's position to ensure it doesn't go out of bounds (optional safeguard)
////        Vector3 position = transform.position;
////        position.y = Mathf.Clamp(position.y, -3.8f, 3.8f);  // Adjust these values based on your wall positions
////        position.z = 0;  // Keep the ball on the Z plane
////        transform.position = position;

////        // Ensure sufficient vertical velocity
////        if (Mathf.Abs(ballVelocity.y) < 0.5f)
////        {
////            rb.velocity = new Vector3(ballVelocity.x, Mathf.Sign(ballVelocity.y) * 0.5f, ballVelocity.z);
////        }

////        // Ensure sufficient horizontal velocity
////        if (Mathf.Abs(ballVelocity.x) < 0.5f)
////        {
////            rb.velocity = new Vector3(Mathf.Sign(ballVelocity.x) * 0.5f, rb.velocity.y, ballVelocity.z);
////        }
////    }

////    private void OnTriggerEnter(Collider other)
////    {
////        if (other.CompareTag("Goal1"))
////        {
////            GameManager.Instance.AddScore(1);  // Add only 1 point instead of 2
////            ResetBall();
////        }
////        else if (other.CompareTag("Goal2"))
////        {
////            GameManager.Instance.AddScore(1);  // Adjust to 1 if necessary
////            ResetBall();
////        }
////    }

////    // Reset the ball's position to the center and start the movement again
////    private void ResetBall()
////    {
////        transform.position = Vector3.zero;  // Move the ball to the center
////        StartBall();  // Start the ball's movement again

////        // Clear the trail to avoid messy remnants
////        TrailRenderer trail = GetComponent<TrailRenderer>();
////        if (trail != null)
////        {
////            trail.Clear();  // Clears the trail each time the ball resets
////        }
////    }

////    public void TeleportBall(Vector2 teleportRangeX, Vector2 teleportRangeY)
////    {
////        // Generate random X and Y positions within the specified range
////        float randomX = Random.Range(teleportRangeX.x, teleportRangeX.y);
////        float randomY = Random.Range(teleportRangeY.x, teleportRangeY.y);

////        // Teleport the ball to the new random position inside the walls
////        transform.position = new Vector3(randomX, randomY, 0);

////        Debug.Log($"Ball teleported to: ({randomX}, {randomY})");
////    }

////}

////using UnityEngine;
////using System.Collections;

////public class BallController : MonoBehaviour
////{
////    public float speed = 10f;       // Starting speed of the ball
////    public float maxSpeed = 15f;    // Maximum allowed speed
////    public float minSpeed = 10f;    // Minimum allowed speed
////    private Rigidbody rb;           // Reference to the ball's Rigidbody

////    // Public references to the paddles
////    public GameObject leftPaddle;
////    public GameObject rightPaddle;

////    private void Start()
////    {
////        rb = GetComponent<Rigidbody>();
////        StartBall(); // Start ball movement when the game begins
////    }

////    public void StartBall()
////    {
////        // Randomize the initial direction of the ball (either left or right, up or down)
////        float directionX = Random.Range(0, 2) == 0 ? 1 : -1;
////        float directionY = Random.Range(0, 2) == 0 ? 1 : -1;

////        // Set the ball's velocity with some vertical and horizontal component
////        Vector3 initialVelocity = new Vector3(speed * directionX, speed * directionY + Random.Range(0.5f, 1.5f), 0);
////        rb.velocity = initialVelocity;
////    }

////    private void Update()
////    {
////        ClampBallSpeed(); // Ensure the ball's speed stays within the allowed limits

////        // Ensure the ball's z position stays fixed at 0 (since it's a 2D game in a 3D space)
////        Vector3 position = transform.position;
////        position.z = 0;
////        transform.position = position;
////    }

////    private void ClampBallSpeed()
////    {
////        float currentSpeed = rb.velocity.magnitude;

////        // Ensure the ball's speed is not less than the minimum speed
////        if (currentSpeed < minSpeed)
////        {
////            rb.velocity = rb.velocity.normalized * (minSpeed + 1f);  // Add a small buffer
////        }
////        // Ensure the ball's speed does not exceed the maximum speed
////        else if (currentSpeed > maxSpeed)
////        {
////            rb.velocity = rb.velocity.normalized * maxSpeed;
////        }
////    }

////    // Method to apply a speed boost to the ball
////    public void ApplySpeedBoost(float multiplier, float duration)
////    {
////        StartCoroutine(SpeedBoost(multiplier, duration));
////    }

////    private IEnumerator SpeedBoost(float multiplier, float duration)
////    {
////        // Multiply the ball's velocity to apply the speed boost
////        rb.velocity *= multiplier;

////        // Wait for the duration of the speed boost effect
////        yield return new WaitForSeconds(duration);

////        // Reset the ball's speed back to the original speed after the boost ends
////        rb.velocity /= multiplier;

////        // Ensure the ball's speed stays within the allowed limits after the boost ends
////        ClampBallSpeed();
////    }

////    // Method to teleport the ball to a random position within a given range
////    public void TeleportBall(Vector2 teleportRangeX, Vector2 teleportRangeY)
////    {
////        // Generate random X and Y positions within the specified range
////        float randomX = Random.Range(teleportRangeX.x, teleportRangeX.y);
////        float randomY = Random.Range(teleportRangeY.x, teleportRangeY.y);

////        // Teleport the ball to the new random position inside the walls
////        transform.position = new Vector3(randomX, randomY, 0);

////        Debug.Log($"Ball teleported to: ({randomX}, {randomY})");
////    }

////    // Detect collisions with walls and paddles
////    private void OnCollisionEnter(Collision collision)
////    {
////        // Handle Left Wall Collision
////        if (collision.gameObject.CompareTag("LeftWall"))
////        {
////            PaddleController leftPaddleController = leftPaddle.GetComponent<PaddleController>();
////            if (leftPaddleController != null)
////            {
////                leftPaddleController.DecreasePaddleSize();
////            }
////        }
////        // Handle Right Wall Collision
////        else if (collision.gameObject.CompareTag("RightWall"))
////        {
////            PaddleController rightPaddleController = rightPaddle.GetComponent<PaddleController>();
////            if (rightPaddleController != null)
////            {
////                rightPaddleController.DecreasePaddleSize();
////            }
////        }
////    }
////}

//using UnityEngine;
//using System.Collections;

//public class BallController : MonoBehaviour
//{
//    public float speed = 10f;       // Starting speed of the ball
//    public float maxSpeed = 15f;    // Maximum allowed speed
//    public float minSpeed = 10f;    // Minimum allowed speed
//    private Rigidbody rb;           // Reference to the ball's Rigidbody

//    // Public references to the paddles
//    public GameObject leftPaddle;
//    public GameObject rightPaddle;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        StartBall(); // Start ball movement when the game begins
//    }

//    public void StartBall()
//    {
//        // Randomize the initial direction of the ball (either left or right, up or down)
//        float directionX = Random.Range(0, 2) == 0 ? 1 : -1;
//        float directionY = Random.Range(0, 2) == 0 ? 1 : -1;

//        // Set the ball's velocity with some vertical and horizontal component
//        Vector3 initialVelocity = new Vector3(speed * directionX, speed * directionY + Random.Range(0.5f, 1.5f), 0);
//        rb.velocity = initialVelocity;
//    }

//    private void Update()
//    {
//        ClampBallSpeed(); // Ensure the ball's speed stays within the allowed limits
//        ClampBallPosition(); // Ensure the ball's position is clamped to prevent it from going out of bounds

//        // Ensure the ball's z position stays fixed at 0 (since it's a 2D game in a 3D space)
//        Vector3 position = transform.position;
//        position.z = 0;
//        transform.position = position;
//    }

//    private void ClampBallSpeed()
//    {
//        float currentSpeed = rb.velocity.magnitude;

//        // Ensure the ball's speed is not less than the minimum speed
//        if (currentSpeed < minSpeed)
//        {
//            rb.velocity = rb.velocity.normalized * (minSpeed + 1f);  // Add a small buffer
//        }
//        // Ensure the ball's speed does not exceed the maximum speed
//        else if (currentSpeed > maxSpeed)
//        {
//            rb.velocity = rb.velocity.normalized * maxSpeed;
//        }
//    }

//    private void ClampBallPosition()
//    {
//        // Clamp the ball's Y position so it doesn't go out of bounds vertically
//        Vector3 position = transform.position;
//        position.y = Mathf.Clamp(position.y, -4.5f, 4.5f); // Adjust bounds according to your game's walls
//        transform.position = position;
//    }

//    // Method to apply a speed boost to the ball
//    public void ApplySpeedBoost(float multiplier, float duration)
//    {
//        StartCoroutine(SpeedBoost(multiplier, duration));
//    }

//    private IEnumerator SpeedBoost(float multiplier, float duration)
//    {
//        // Multiply the ball's velocity to apply the speed boost
//        rb.velocity *= multiplier;

//        // Wait for the duration of the speed boost effect
//        yield return new WaitForSeconds(duration);

//        // Reset the ball's speed back to the original speed after the boost ends
//        rb.velocity /= multiplier;

//        // Ensure the ball's speed stays within the allowed limits after the boost ends
//        ClampBallSpeed();
//    }

//    // Method to teleport the ball to a random position within a given range
//    public void TeleportBall(Vector2 teleportRangeX, Vector2 teleportRangeY)
//    {
//        // Generate random X and Y positions within the specified range
//        float randomX = Random.Range(teleportRangeX.x, teleportRangeX.y);
//        float randomY = Random.Range(teleportRangeY.x, teleportRangeY.y);

//        // Teleport the ball to the new random position inside the walls
//        transform.position = new Vector3(randomX, randomY, 0);

//        Debug.Log($"Ball teleported to: ({randomX}, {randomY})");
//    }

//    // Detect collisions with walls and paddles
//    private void OnCollisionEnter(Collision collision)
//    {
//        // Handle Left Wall Collision
//        if (collision.gameObject.CompareTag("LeftWall"))
//        {
//            PaddleController leftPaddleController = leftPaddle.GetComponent<PaddleController>();
//            if (leftPaddleController != null)
//            {
//                leftPaddleController.DecreasePaddleSize();
//            }
//        }
//        // Handle Right Wall Collision
//        else if (collision.gameObject.CompareTag("RightWall"))
//        {
//            PaddleController rightPaddleController = rightPaddle.GetComponent<PaddleController>();
//            if (rightPaddleController != null)
//            {
//                rightPaddleController.DecreasePaddleSize();
//            }
//        }
//    }
//}

using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public float speed = 10f;       // Starting speed of the ball
    public float maxSpeed = 15f;    // Maximum allowed speed
    public float minSpeed = 10f;    // Minimum allowed speed
    private Rigidbody rb;           // Reference to the ball's Rigidbody

    // Public references to the paddles
    public GameObject leftPaddle;
    public GameObject rightPaddle;

    private GameController gameController;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameController = FindObjectOfType<GameController>();  // Automatically find the GameController in the scene
        StartBall(); // Start ball movement when the game begins

        // Check if the GameController reference is null
        if (gameController == null)
        {
            Debug.LogError("GameController not found. Please ensure there is a GameController in the scene.");
        }
    }

    public void StartBall()
    {
        // Randomize the initial direction of the ball (either left or right, up or down)
        float directionX = Random.Range(0, 2) == 0 ? 1 : -1;
        float directionY = Random.Range(0.5f, 1.5f) * (Random.Range(0, 2) == 0 ? 1 : -1);

        // Set the ball's velocity with some vertical and horizontal component
        Vector3 initialVelocity = new Vector3(speed * directionX, speed * directionY, 0); rb.velocity = initialVelocity;
    }

    //public void StartBall()
    //{
    //    // Randomize the initial direction of the ball (either left or right)
    //    float directionX = Random.Range(0, 2) == 0 ? 1 : -1;

    //    // Ensure the ball always moves vertically
    //    float directionY = Random.Range(0.5f, 1.5f) * (Random.Range(0, 2) == 0 ? 1 : -1);

    //    // Set the ball's velocity with a strong horizontal and vertical component
    //    Vector3 initialVelocity = new Vector3(speed * directionX, speed * directionY, 0);
    //    rb.velocity = initialVelocity;
    //}

    private void Update()
    {
        ClampBallSpeed(); // Ensure the ball's speed stays within the allowed limits

        // Ensure the ball's z position stays fixed at 0 (since it's a 2D game in a 3D space)
        Vector3 position = transform.position;
        position.z = 0;
        transform.position = position;
    }

    private void ClampBallSpeed()
    {
        float currentSpeed = rb.velocity.magnitude;

        // Ensure the ball's speed is not less than the minimum speed
        if (currentSpeed < minSpeed)
        {
            rb.velocity = rb.velocity.normalized * (minSpeed + 1f);  // Add a small buffer
        }
        // Ensure the ball's speed does not exceed the maximum speed
        else if (currentSpeed > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    // Method to apply a speed boost to the ball
    public void ApplySpeedBoost(float multiplier, float duration)
    {
        StartCoroutine(SpeedBoost(multiplier, duration));
    }

    private IEnumerator SpeedBoost(float multiplier, float duration)
    {
        // Multiply the ball's velocity to apply the speed boost
        rb.velocity *= multiplier;

        // Wait for the duration of the speed boost effect
        yield return new WaitForSeconds(duration);

        // Reset the ball's speed back to the original speed after the boost ends
        rb.velocity /= multiplier;

        // Ensure the ball's speed stays within the allowed limits after the boost ends
        ClampBallSpeed();
    }

    // Method to teleport the ball to a random position within a given range
    public void TeleportBall(Vector2 teleportRangeX, Vector2 teleportRangeY)
    {
        // Generate random X and Y positions within the specified range
        float randomX = Random.Range(teleportRangeX.x, teleportRangeX.y);
        float randomY = Random.Range(teleportRangeY.x, teleportRangeY.y);

        // Teleport the ball to the new random position inside the walls
        transform.position = new Vector3(randomX, randomY, 0);

        Debug.Log($"Ball teleported to: ({randomX}, {randomY})");
    }

    // Detect collisions with walls and paddles
    private void OnCollisionEnter(Collision collision)
    {
        // Handle Left Wall Collision
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            PaddleController leftPaddleController = leftPaddle.GetComponent<PaddleController>();
            if (leftPaddleController != null)
            {
                gameController.AddScore(2);
                leftPaddleController.DecreasePaddleSize();
                ResetBall();
            }
        }
        // Handle Right Wall Collision
        else if (collision.gameObject.CompareTag("RightWall"))
        {
            PaddleController rightPaddleController = rightPaddle.GetComponent<PaddleController>();
            if (rightPaddleController != null)
            {
                gameController.AddScore(1);
                rightPaddleController.DecreasePaddleSize();
                ResetBall();
            }
        }
    }

    private void ResetBall()
    {
        transform.position = Vector3.zero; 
        StartBall(); 
    }


    ////Detect collisions with walls and paddles
    //private void OnCollisionEnter(Collision collision)
    //{
    //    // Handle Left Wall (Goal1) Collision - Player 2 scores
    //    if (collision.gameObject.CompareTag("Goal1"))
    //    {
    //        gameController.AddScore(2);  // Notify GameController that Player 2 scored
    //        ResetBall();  // Reset the ball to the center
    //    }

    //    // Handle Right Wall (Goal2) Collision - Player 1 scores
    //    else if (collision.gameObject.CompareTag("Goal2"))
    //    {
    //        gameController.AddScore(1);  // Notify GameController that Player 1 scored
    //        ResetBall();  // Reset the ball to the center
    //    }

    //    // Handle collisions with paddles
    //    if (collision.gameObject.CompareTag("Paddle"))
    //    {
    //        // Optional: Add any paddle-related logic here
    //    }
    //}

}
