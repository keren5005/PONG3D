using UnityEngine;

public class BallPowerUp : MonoBehaviour
{
    public float speedBoostMultiplier = 1.5f;  // Speed boost multiplier for the ball
    public float effectDuration = 5f;          // Duration of the power-up effect
    public ParticleSystem collectEffect;       // Reference to the particle system for collection effect

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            BallController ball = other.GetComponent<BallController>();
            if (ball != null)
            {
                ball.ApplySpeedBoost(speedBoostMultiplier, effectDuration);
            }

            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);  
        }
    }
}
