using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    private Vector3 initialPosition;
    private Renderer capsuleRenderer;
    private Collider capsuleCollider;

    public float speedBoost = 1.5f;  // Speed boost for the ball when it hits the capsule

    private void Start()
    {
        
        initialPosition = transform.position;

       
        capsuleRenderer = GetComponent<Renderer>();
        capsuleCollider = GetComponent<Collider>();

        if (capsuleRenderer == null || capsuleCollider == null)
        {
            Debug.LogError("Capsule is missing Renderer or Collider components!");
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Ball"))
        {
            
            BallController ballController = collision.gameObject.GetComponent<BallController>();

            if (ballController != null)
            {
                
                ballController.ApplySpeedBoost(1.5f, 5f);
            }

           
        }
    }

   
    public void PrepareCapsule()
    {
       
        if (capsuleRenderer != null)
        {
            capsuleRenderer.enabled = true;  
        }

        if (capsuleCollider != null)
        {
            capsuleCollider.enabled = true;  
        }

        gameObject.SetActive(true); 
    }

    public Vector3 GetInitialPosition()
    {
        return initialPosition;
    }

    public void ResetCapsulePosition()
    {
        
        transform.position = initialPosition;
    }



}
