using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;  // Speed of paddle movement
    public bool isPlayer1;     // Check if this paddle belongs to Player 1
    public Material glowMaterial;  // Reference to the glowing pink material
    private Renderer paddleRenderer;  // Reference to the paddle's renderer

    private float minY, maxY;  // Boundaries for paddle movement
    private float paddleHeight;  // Height of paddle to adjust boundary calculations
    private Vector3 originalSize;  // Store the original paddle size for resetting

    private void Start()
    {
        
        originalSize = transform.localScale;

        
        paddleRenderer = GetComponent<Renderer>();

        
        if (glowMaterial != null)
        {
            paddleRenderer.material = glowMaterial;
        }

       
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2f, transform.localScale.z);  // Example: Double the height of the paddle

       
        UpdatePaddleBoundaries();
    }

    private void Update()
    {
        
        float moveInput = isPlayer1 ? Input.GetAxis("Vertical1") : Input.GetAxis("Vertical2");
        Vector3 move = new Vector3(0, moveInput * speed * Time.deltaTime, 0);
        transform.Translate(move);

        ClampPosition();
    }


   
    private void UpdatePaddleBoundaries()
    {
        paddleHeight = GetComponent<Collider>().bounds.size.y / 2;
        minY = -5.6f + paddleHeight;  
        maxY = 5.6f - paddleHeight;   
    }

    private void ClampPosition()
    {
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }

    public void ResetPaddleSize()
    {
        
        transform.localScale = new Vector3(transform.localScale.x, 2f, transform.localScale.z);
    }

    public void DecreasePaddleSize()
    {
        if (transform.localScale.y > 0.5f) 
        {
            
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 0.9f, transform.localScale.z);
        }
    }

}

