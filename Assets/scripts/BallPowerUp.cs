//using UnityEngine;

//public class BallPowerUp : MonoBehaviour
//{
//    public float speedBoostMultiplier = 1.5f;  // Speed boost multiplier for the ball
//    public float effectDuration = 5f;  // Duration of the power-up effect

//    void OnTriggerEnter(Collider other)
//    {
//        // Check if the object that collided with the power-up is the ball
//        if (other.CompareTag("Ball"))
//        {
//            BallController ball = other.GetComponent<BallController>();
//            if (ball != null)
//            {
//                // Apply the effect to the ball (e.g., speed boost)
//                ball.ApplySpeedBoost(speedBoostMultiplier, effectDuration);
//            }

//            // Destroy the power-up after it has been collected
//            Destroy(gameObject);  // Remove the capsule or sphere after use
//        }
//    }
//}

using UnityEngine;

public class BallPowerUp : MonoBehaviour
{
    public float speedBoostMultiplier = 1.5f;  // Speed boost multiplier for the ball
    public float effectDuration = 5f;          // Duration of the power-up effect
    public ParticleSystem collectEffect;       // Reference to the particle system for collection effect

    void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided with the power-up is the ball
        if (other.CompareTag("Ball"))
        {
            BallController ball = other.GetComponent<BallController>();
            if (ball != null)
            {
                // Apply the effect to the ball (e.g., speed boost)
                ball.ApplySpeedBoost(speedBoostMultiplier, effectDuration);
            }

            // Play the collection particle effect if assigned
            if (collectEffect != null)
            {
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            }

            // Destroy the power-up after it has been collected
            Destroy(gameObject);  // Remove the capsule or sphere after use
        }
    }
}
