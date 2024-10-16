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
        gameController = FindObjectOfType<GameController>();  
        StartBall(); 

        
        if (gameController == null)
        {
            Debug.LogError("GameController not found. Please ensure there is a GameController in the scene.");
        }
    }

    public void StartBall()
    {
        
        float directionX = Random.Range(0, 2) == 0 ? 1 : -1;
        float directionY = Random.Range(0.5f, 1.5f) * (Random.Range(0, 2) == 0 ? 1 : -1);

        
        Vector3 initialVelocity = new Vector3(speed * directionX, speed * directionY, 0); rb.velocity = initialVelocity;
    }


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

        if (currentSpeed < minSpeed)
        {
            rb.velocity = rb.velocity.normalized * (minSpeed + 1f);  // Add a small buffer
        }
        else if (currentSpeed > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    public void ApplySpeedBoost(float multiplier, float duration)
    {
        StartCoroutine(SpeedBoost(multiplier, duration));
    }

    private IEnumerator SpeedBoost(float multiplier, float duration)
    {
        rb.velocity *= multiplier;

        yield return new WaitForSeconds(duration);

        rb.velocity /= multiplier;

        ClampBallSpeed();
    }

    public void TeleportBall(Vector2 teleportRangeX, Vector2 teleportRangeY)
    {
       
        float randomX = Random.Range(teleportRangeX.x, teleportRangeX.y);
        float randomY = Random.Range(teleportRangeY.x, teleportRangeY.y);

        transform.position = new Vector3(randomX, randomY, 0);

        Debug.Log($"Ball teleported to: ({randomX}, {randomY})");
    }

    private void OnCollisionEnter(Collision collision)
    {
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

}
