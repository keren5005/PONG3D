using UnityEngine;

public class TeleportationPowerUp : MonoBehaviour
{
    public Vector2 teleportRangeX = new Vector2(-7f, 7f);  // X axis range
    public Vector2 teleportRangeY = new Vector2(-4f, 4f);  // Y axis range

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            BallController ball = collision.gameObject.GetComponent<BallController>();
            if (ball != null)
            {
                ball.TeleportBall(teleportRangeX, teleportRangeY);
            }

            Destroy(gameObject);
        }
    }
}
