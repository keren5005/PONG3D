using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    private Vector3 initialPosition;
    private Renderer capsuleRenderer;
    private Collider capsuleCollider;

    public float speedBoost = 1.5f;  // Speed boost for the ball when it hits the capsule

    private void Start()
    {
        // Store the initial position of the capsule only once when the game starts
        initialPosition = transform.position;

        // Get references to the Renderer and Collider components
        capsuleRenderer = GetComponent<Renderer>();
        capsuleCollider = GetComponent<Collider>();

        if (capsuleRenderer == null || capsuleCollider == null)
        {
            Debug.LogError("Capsule is missing Renderer or Collider components!");
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the ball
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Get the BallController component
            BallController ballController = collision.gameObject.GetComponent<BallController>();

            if (ballController != null)
            {
                // Apply a speed boost, e.g., 1.5x speed for 5 seconds
                ballController.ApplySpeedBoost(1.5f, 5f);
            }

            // Optionally, you could add visual feedback or other effects here
        }
    }

    // This method will only ensure the capsule remains visible and interactable, not reset the position
    public void PrepareCapsule()
    {
        // Ensure the capsule is visible and interactable when the game begins
        if (capsuleRenderer != null)
        {
            capsuleRenderer.enabled = true;  // Make sure it's visible
        }

        if (capsuleCollider != null)
        {
            capsuleCollider.enabled = true;  // Make sure it's interactable
        }

        gameObject.SetActive(true);  // Ensure the capsule is active in the scene
    }

    public Vector3 GetInitialPosition()
    {
        return initialPosition;
    }

    public void ResetCapsulePosition()
    {
        // Reset the capsule's position to its initial position
        transform.position = initialPosition;
    }



}
