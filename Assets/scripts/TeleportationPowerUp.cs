using UnityEngine;

public class TeleportationPowerUp : MonoBehaviour
{
    public Vector2 teleportRangeX = new Vector2(-7f, 7f);  // X axis range
    public Vector2 teleportRangeY = new Vector2(-4f, 4f);  // Y axis range

    private void OnCollisionEnter(Collision collision)
    {
        // Ensure the object that collided is the ball
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Get the ball's BallController script
            BallController ball = collision.gameObject.GetComponent<BallController>();
            if (ball != null)
            {
                // Teleport the ball to a random location within the range
                ball.TeleportBall(teleportRangeX, teleportRangeY);
            }

            // Destroy the power-up after collection
            Destroy(gameObject);
        }
    }
}
