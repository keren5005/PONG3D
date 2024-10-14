//////using UnityEngine;
//////using UnityEngine.UI;

//////public class GameController : MonoBehaviour
//////{
//////    public GameObject startButton;
//////    public GameObject playAgainButton;
//////    public Text winMessageText;
//////    public GameObject ball;
//////    public GameObject[] paddles;
//////    public GameObject[] capsules;

//////    public Text player1ScoreText;
//////    public Text player2ScoreText;

//////    private void Start()
//////    {
//////        if (startButton == null || playAgainButton == null || winMessageText == null)
//////        {
//////            Debug.LogError("Start Button, Play Again Button, or Win Message Text is not assigned in the Inspector.");
//////            return;
//////        }

//////        ShowStartButton();
//////    }

//////    private void ShowStartButton()
//////    {
//////        startButton.SetActive(true);
//////        playAgainButton.SetActive(false);
//////        winMessageText.gameObject.SetActive(false);
//////        Time.timeScale = 0f;
//////    }

//////    public void StartGame()
//////    {
//////        startButton.SetActive(false);
//////        playAgainButton.SetActive(false);
//////        winMessageText.gameObject.SetActive(false);
//////        Time.timeScale = 1f;
//////        ResetBallAndPaddles();
//////    }

//////    public void ResetGame()
//////    {
//////        // Reset the scores in GameManager
//////        GameManager.Instance.ResetGame();

//////        // Hide the play again button and win message
//////        playAgainButton.SetActive(false);
//////        winMessageText.text = "";
//////        winMessageText.gameObject.SetActive(false);

//////        // Reset the score UI to 0 for both players
//////        UpdateScoreUI(1, 0);  // Player 1 score
//////        UpdateScoreUI(2, 0);  // Player 2 score

//////        // Reset the ball's position, paddles' positions and sizes, and ball's trail
//////        ResetBallAndPaddles();

//////        // Reset any power-ups or capsules
//////        ResetCapsules();  // Ensure this function resets or deactivates power-ups

//////        // Resume the game
//////        Time.timeScale = 1f;
//////    }

//////    private void ResetBallAndPaddles()
//////    {
//////        // Reset the ball
//////        if (ball != null)
//////        {
//////            // Reset ball position
//////            ball.transform.position = Vector3.zero;

//////            // Reset the ball's movement
//////            ball.GetComponent<BallController>().StartBall();

//////            // Reset the ball's trail
//////            TrailRenderer trail = ball.GetComponent<TrailRenderer>();
//////            if (trail != null)
//////            {
//////                trail.Clear();  // Clear the trail so there are no remnants
//////            }
//////        }

//////        // Reset the paddles
//////        if (paddles != null)
//////        {
//////            foreach (GameObject paddle in paddles)
//////            {
//////                // Reset paddle position
//////                paddle.transform.position = new Vector3(paddle.transform.position.x, 0f, paddle.transform.position.z);

//////                // Reset paddle size (if it has been modified during gameplay)
//////                PaddleController paddleController = paddle.GetComponent<PaddleController>();
//////                if (paddleController != null)
//////                {
//////                    paddleController.ResetPaddleSize();  // Reset paddle to its original size
//////                }
//////            }
//////        }

//////        // Reset the capsules (e.g., power-ups)
//////        ResetCapsules();  // Call to the method that handles capsule resets
//////    }

//////    private void ResetCapsules()
//////    {
//////        GameObject[] capsules = GameObject.FindGameObjectsWithTag("Capsule"); // Ensure "Capsule" matches exactly

//////        foreach (GameObject capsule in capsules)
//////        {
//////            capsule.SetActive(false);  // Deactivate the capsule
//////            capsule.SetActive(true);   // Reactivate it (or adjust logic if needed)
//////        }
//////    }


//////    public void ResetPaddleSize()
//////    {
//////        // Assuming the initial paddle size is (1, 1, 1)
//////        transform.localScale = new Vector3(1, 1, 1);
//////    }

//////    public void UpdateScoreUI(int playerIndex, int score)
//////    {
//////        if (playerIndex == 1)
//////        {
//////            player1ScoreText.text = score.ToString();
//////        }
//////        else if (playerIndex == 2)
//////        {
//////            player2ScoreText.text = score.ToString();
//////        }
//////    }

//////    public void GameOver(string winnerMessage)
//////    {
//////        playAgainButton.SetActive(true);
//////        winMessageText.gameObject.SetActive(true);
//////        winMessageText.text = winnerMessage;
//////        Time.timeScale = 0f;
//////    }
//////}

//////using UnityEngine;
//////using UnityEngine.UI;

//////public class GameController : MonoBehaviour
//////{
//////    public GameObject startButton;
//////    public GameObject playAgainButton;
//////    public Text winMessageText;
//////    public GameObject ball;
//////    public GameObject[] paddles;

//////    public Text player1ScoreText;
//////    public Text player2ScoreText;

//////    private void Start()
//////    {
//////        if (startButton == null || playAgainButton == null || winMessageText == null)
//////        {
//////            Debug.LogError("Start Button, Play Again Button, or Win Message Text is not assigned in the Inspector.");
//////            return;
//////        }

//////        ShowStartButton();
//////    }

//////    private void ShowStartButton()
//////    {
//////        startButton.SetActive(true);
//////        playAgainButton.SetActive(false);
//////        winMessageText.gameObject.SetActive(false);
//////        Time.timeScale = 0f;
//////    }

//////    public void StartGame()
//////    {
//////        startButton.SetActive(false);
//////        playAgainButton.SetActive(false);
//////        winMessageText.gameObject.SetActive(false);
//////        Time.timeScale = 1f;
//////        ResetBallAndPaddles();
//////    }

//////    public void ResetGame()
//////    {
//////        // Reset the scores in GameManager
//////        GameManager.Instance.ResetGame();

//////        // Hide the play again button and win message
//////        playAgainButton.SetActive(false);
//////        winMessageText.text = "";
//////        winMessageText.gameObject.SetActive(false);

//////        // Reset the score UI to 0 for both players
//////        UpdateScoreUI(1, 0);  // Player 1 score
//////        UpdateScoreUI(2, 0);  // Player 2 score

//////        // Reset the ball's position, paddles' positions and sizes, and ball's trail
//////        ResetBallAndPaddles();

//////        // Reset any power-ups or capsules
//////        ResetCapsules();  // Ensure this function resets or deactivates power-ups

//////        // Resume the game
//////        Time.timeScale = 1f;
//////    }

//////    private void ResetBallAndPaddles()
//////    {
//////        // Reset the ball
//////        if (ball != null)
//////        {
//////            // Reset ball position
//////            ball.transform.position = Vector3.zero;

//////            // Reset the ball's movement
//////            ball.GetComponent<BallController>().StartBall();

//////            // Reset the ball's trail
//////            TrailRenderer trail = ball.GetComponent<TrailRenderer>();
//////            if (trail != null)
//////            {
//////                trail.Clear();  // Clear the trail so there are no remnants
//////            }
//////        }

//////        // Reset the paddles
//////        if (paddles != null)
//////        {
//////            foreach (GameObject paddle in paddles)
//////            {
//////                // Reset paddle position
//////                paddle.transform.position = new Vector3(paddle.transform.position.x, 0f, paddle.transform.position.z);

//////                // Reset paddle size (if it has been modified during gameplay)
//////                PaddleController paddleController = paddle.GetComponent<PaddleController>();
//////                if (paddleController != null)
//////                {
//////                    paddleController.ResetPaddleSize();  // Reset paddle to its original size
//////                }
//////            }
//////        }

//////        // Reset the capsules (e.g., power-ups)
//////        ResetCapsules();  // Call to the method that handles capsule resets
//////    }

//////    private void ResetCapsules()
//////    {
//////        GameObject[] capsules = GameObject.FindGameObjectsWithTag("Capsule"); // Ensure "Capsule" matches exactly

//////        foreach (GameObject capsule in capsules)
//////        {
//////            capsule.SetActive(false);  // Deactivate the capsule
//////            capsule.SetActive(true);   // Reactivate it (or adjust logic if needed)
//////        }
//////    }


//////    public void ResetPaddleSize()
//////    {
//////        // Assuming the initial paddle size is (1, 1, 1)
//////        transform.localScale = new Vector3(1, 1, 1);
//////    }

//////    public void UpdateScoreUI(int playerIndex, int score)
//////    {
//////        if (playerIndex == 1)
//////        {
//////            player1ScoreText.text = score.ToString();
//////        }
//////        else if (playerIndex == 2)
//////        {
//////            player2ScoreText.text = score.ToString();
//////        }
//////    }

//////    public void GameOver(string winnerMessage)
//////    {
//////        playAgainButton.SetActive(true);
//////        winMessageText.gameObject.SetActive(true);
//////        winMessageText.text = winnerMessage;
//////        Time.timeScale = 0f;
//////    }
//////}




//////*************************************************************************

////using UnityEngine;
////using UnityEngine.UI;

////public class GameController : MonoBehaviour
////{
////    public GameObject startButton;
////    public GameObject playAgainButton;
////    public Text winMessageText;
////    public GameObject ball;

////    public GameObject paddle1;  // Assign the first paddle in the Inspector
////    public GameObject paddle2;  // Assign the second paddle in the Inspector

////    public GameObject capsule1;  // Assign the first capsule in the Inspector
////    public GameObject capsule2;  // Assign the second capsule in the Inspector

////    public Text player1ScoreText;
////    public Text player2ScoreText;

////    private Vector3 paddle1StartPosition;
////    private Vector3 paddle2StartPosition;
////    private Vector3 paddle1StartScale;
////    private Vector3 paddle2StartScale;
////    private Vector3 capsule1StartPosition;
////    private Vector3 capsule2StartPosition;

////    public GameObject wall1;
////    public GameObject wall2;
////    public GameObject wall3;
////    public GameObject wall4;


////    private void Start()
////    {
////        // Ensure StartButton, PlayAgainButton, and WinMessageText are assigned
////        if (startButton == null || playAgainButton == null || winMessageText == null)
////        {
////            Debug.LogError("Start Button, Play Again Button, or Win Message Text is not assigned in the Inspector.");
////            return;
////        }

////        // Store initial positions and scales of paddles and capsules at the start of the game
////        if (paddle1 != null)
////        {
////            paddle1StartPosition = paddle1.transform.position;
////            paddle1StartScale = paddle1.transform.localScale;  // Store initial scale of paddle1
////        }

////        if (paddle2 != null)
////        {
////            paddle2StartPosition = paddle2.transform.position;
////            paddle2StartScale = paddle2.transform.localScale;  // Store initial scale of paddle2
////        }

////        if (capsule1 != null)
////        {
////            capsule1StartPosition = capsule1.transform.position;  // Store initial position of capsule1
////        }

////        if (capsule2 != null)
////        {
////            capsule2StartPosition = capsule2.transform.position;  // Store initial position of capsule2
////        }

////        // Show the start button at the beginning of the game
////        ShowStartButton();
////    }


////    private void ShowStartButton()
////    {
////        startButton.SetActive(true);
////        playAgainButton.SetActive(false);
////        winMessageText.gameObject.SetActive(false);
////        Time.timeScale = 0f;
////    }

////    public void StartGame()
////    {
////        startButton.SetActive(false);
////        playAgainButton.SetActive(false);
////        winMessageText.gameObject.SetActive(false);
////        Time.timeScale = 1f;
////        ResetBallAndPaddles();
////        ResetCapsules();
////    }

////    //public void ResetGame()
////    //{
////    //    // Reset the scores in GameManager
////    //    GameManager.Instance.ResetGame();

////    //    // Hide the play again button and win message
////    //    playAgainButton.SetActive(false);
////    //    winMessageText.text = "";
////    //    winMessageText.gameObject.SetActive(false);

////    //    // Reset the score UI to 0 for both players
////    //    UpdateScoreUI(1, 0);  // Player 1 score
////    //    UpdateScoreUI(2, 0);  // Player 2 score

////    //    // Reset the ball's position, paddles' positions and sizes, and ball's trail
////    //    ResetBallAndPaddles();

////    //    // Reset the capsules
////    //    ResetCapsules();

////    //    // Resume the game
////    //    Time.timeScale = 1f;
////    //}

////    //public void ResetGame()
////    //{
////    //    // Existing code to reset the scores in GameManager
////    //    GameManager.Instance.ResetGame();

////    //    // Hide the play again button and win message
////    //    playAgainButton.SetActive(false);
////    //    winMessageText.text = "";
////    //    winMessageText.gameObject.SetActive(false);

////    //    // Reset the score UI to 0 for both players
////    //    UpdateScoreUI(1, 0);  // Player 1 score
////    //    UpdateScoreUI(2, 0);  // Player 2 score

////    //    // Reset the ball's position, paddles' positions and sizes, and ball's trail
////    //    ResetBallAndPaddles();

////    //    // Reset any power-ups or capsules
////    //    ResetCapsules();

////    //    // Additional resets for the game state:

////    //    // 1. Reset the ball and start its movement again.
////    //    if (ball != null)
////    //    {
////    //        ball.transform.position = Vector3.zero;
////    //        ball.GetComponent<BallController>().StartBall();

////    //        // Clear the trail of the ball (if it has one).
////    //        TrailRenderer trail = ball.GetComponent<TrailRenderer>();
////    //        if (trail != null)
////    //        {
////    //            trail.Clear();
////    //        }
////    //    }

////    //    // 2. Reset paddles' sizes and positions.
////    //    if (paddle1 != null)
////    //    {
////    //        paddle1.transform.position = new Vector3(paddle1.transform.position.x, 0f, paddle1.transform.position.z);
////    //        PaddleController paddleController1 = paddle1.GetComponent<PaddleController>();
////    //        if (paddleController1 != null)
////    //        {
////    //            paddleController1.ResetPaddleSize();  // Reset to original size
////    //        }
////    //    }

////    //    if (paddle2 != null)
////    //    {
////    //        paddle2.transform.position = new Vector3(paddle2.transform.position.x, 0f, paddle2.transform.position.z);
////    //        PaddleController paddleController2 = paddle2.GetComponent<PaddleController>();
////    //        if (paddleController2 != null)
////    //        {
////    //            paddleController2.ResetPaddleSize();  // Reset to original size
////    //        }
////    //    }

////    //    // 3. Reset all capsules (deactivate and reactivate).
////    //    if (capsule1 != null)
////    //    {
////    //        capsule1.SetActive(false);
////    //        capsule1.SetActive(true);  // Reactivate after reset
////    //    }

////    //    if (capsule2 != null)
////    //    {
////    //        capsule2.SetActive(false);
////    //        capsule2.SetActive(true);  // Reactivate after reset
////    //    }

////    //    // 4. Reset any other game objects or logic if necessary.

////    //    // Resume the game (if needed)
////    //    Time.timeScale = 1f;  // Resume the game if it was paused
////    //}

////    //public void ResetGame()
////    //{
////    //    // Reset the scores in GameManager
////    //    GameManager.Instance.ResetGame();

////    //    // Hide the play again button and win message
////    //    playAgainButton.SetActive(false);
////    //    winMessageText.text = "";
////    //    winMessageText.gameObject.SetActive(false);

////    //    // Reset the score UI to 0 for both players
////    //    UpdateScoreUI(1, 0);  // Player 1 score
////    //    UpdateScoreUI(2, 0);  // Player 2 score

////    //    // Reset the ball's position and clear the trail
////    //    ResetBallAndPaddles();  // This will handle paddles and ball resetting

////    //    // Reset all capsules
////    //    ResetCapsules();

////    //    // Resume the game
////    //    Time.timeScale = 1f;  // Resume the game if it was paused
////    //}

////    public void ResetGame()
////    {
////        // Reset the scores, paddles, ball, and capsules
////        GameManager.Instance.ResetGame();

////        // Hide the play again button and win message
////        playAgainButton.SetActive(false);
////        winMessageText.text = "";
////        winMessageText.gameObject.SetActive(false);

////        // Reset score UI
////        UpdateScoreUI(1, 0);
////        UpdateScoreUI(2, 0);

////        // Reset ball, paddles, and walls
////        ResetBallAndPaddles();
////        ResetCapsules();
////        ResetWalls();  // Ensure the walls are reset

////        // Resume the game
////        Time.timeScale = 1f;
////    }

////    private void ResetBallAndPaddles()
////    {
////        // Reset the ball
////        if (ball != null)
////        {
////            ball.transform.position = Vector3.zero;

////            Rigidbody ballRb = ball.GetComponent<Rigidbody>();
////            if (ballRb != null)
////            {
////                ballRb.velocity = Vector3.zero;  // Reset velocity
////                ballRb.angularVelocity = Vector3.zero;  // Reset angular velocity
////            }

////            ball.GetComponent<BallController>().StartBall();

////            TrailRenderer trail = ball.GetComponent<TrailRenderer>();
////            if (trail != null)
////            {
////                trail.Clear();  // Clear any existing trail lines
////            }
////        }

////        // Reset paddle1 size, position, and behavior (like blinking or scaling)
////        if (paddle1 != null)
////        {
////            paddle1.transform.position = paddle1StartPosition;
////            paddle1.transform.localScale = new Vector3(0.5f, 2f, 0.5f);  // Reset paddle size to original
////            PaddleController paddleController1 = paddle1.GetComponent<PaddleController>();
////            if (paddleController1 != null)
////            {
////                paddleController1.ResetPaddleSize();  // Ensure paddle behavior is reset
////            }

////            // Reset any blinking or visual effects here
////            ResetPaddleBlinking(paddle1);  // Example function, if paddles have blinking effects
////        }

////        // Reset paddle2 size, position, and behavior
////        if (paddle2 != null)
////        {
////            paddle2.transform.position = paddle2StartPosition;
////            paddle2.transform.localScale = new Vector3(0.5f, 2f, 0.5f);  // Reset paddle size to original
////            PaddleController paddleController2 = paddle2.GetComponent<PaddleController>();
////            if (paddleController2 != null)
////            {
////                paddleController2.ResetPaddleSize();  // Ensure paddle behavior is reset
////            }

////            // Reset any blinking or visual effects here
////            ResetPaddleBlinking(paddle2);  // Example function, if paddles have blinking effects
////        }
////    }

////    private void ResetPaddleBlinking(GameObject paddle)
////    {
////        // Example: Re-enable blinking or restart the animation if you are using an Animator or a material change
////        Animator paddleAnimator = paddle.GetComponent<Animator>();
////        if (paddleAnimator != null)
////        {
////            paddleAnimator.Play("BlinkingAnimation", -1, 0f);  // Restart blinking animation from the start
////        }

////        // If using a material change for blinking:
////        Renderer paddleRenderer = paddle.GetComponent<Renderer>();
////        if (paddleRenderer != null)
////        {
////            // Reapply original material or reset blinking effect
////            paddleRenderer.material.color = Color.white;  // Example: Reset to original color
////        }
////    }

////    private void ResetWalls()
////    {
////        if (wall1 != null)
////        {
////            wall1.SetActive(true);  // Ensure wall1 is active and visible
////            Renderer wall1Renderer = wall1.GetComponent<Renderer>();
////            if (wall1Renderer != null)
////            {
////                wall1Renderer.enabled = true;  // Make sure the wall is visible
////            }
////        }

////        if (wall2 != null)
////        {
////            wall2.SetActive(true);
////            Renderer wall2Renderer = wall2.GetComponent<Renderer>();
////            if (wall2Renderer != null)
////            {
////                wall2Renderer.enabled = true;
////            }
////        }

////        if (wall3 != null)
////        {
////            wall3.SetActive(true);
////            Renderer wall3Renderer = wall3.GetComponent<Renderer>();
////            if (wall3Renderer != null)
////            {
////                wall3Renderer.enabled = true;
////            }
////        }

////        if (wall4 != null)
////        {
////            wall4.SetActive(true);
////            Renderer wall4Renderer = wall4.GetComponent<Renderer>();
////            if (wall4Renderer != null)
////            {
////                wall4Renderer.enabled = true;
////            }
////        }
////    }


////    private void ResetCapsules()
////    {
////        // Reactivate and reset capsule1
////        if (capsule1 != null)
////        {
////            capsule1.SetActive(true);  // Ensure capsule is active
////            capsule1.transform.position = capsule1StartPosition;  // Reset to initial position

////            // Ensure visibility
////            Renderer capsule1Renderer = capsule1.GetComponent<Renderer>();
////            if (capsule1Renderer != null)
////            {
////                capsule1Renderer.enabled = true;  // Ensure it's visible
////            }

////            // Ensure it's interactable again
////            Collider capsule1Collider = capsule1.GetComponent<Collider>();
////            if (capsule1Collider != null)
////            {
////                capsule1Collider.enabled = true;  // Ensure it's interactable
////            }
////        }

////        // Reactivate and reset capsule2
////        if (capsule2 != null)
////        {
////            capsule2.SetActive(true);  // Ensure capsule is active
////            capsule2.transform.position = capsule2StartPosition;  // Reset to initial position

////            // Ensure visibility
////            Renderer capsule2Renderer = capsule2.GetComponent<Renderer>();
////            if (capsule2Renderer != null)
////            {
////                capsule2Renderer.enabled = true;  // Ensure it's visible
////            }

////            // Ensure it's interactable again
////            Collider capsule2Collider = capsule2.GetComponent<Collider>();
////            if (capsule2Collider != null)
////            {
////                capsule2Collider.enabled = true;  // Ensure it's interactable
////            }
////        }
////    }


////    public void UpdateScoreUI(int playerIndex, int score)
////    {
////        if (playerIndex == 1)
////        {
////            player1ScoreText.text = score.ToString();
////        }
////        else if (playerIndex == 2)
////        {
////            player2ScoreText.text = score.ToString();
////        }
////    }

////    public void GameOver(string winnerMessage)
////    {
////        playAgainButton.SetActive(true);
////        winMessageText.gameObject.SetActive(true);
////        winMessageText.text = winnerMessage;
////        Time.timeScale = 0f;
////    }
////}


//////************************************************************



//using UnityEngine;
//using UnityEngine.UI;

//public class GameController : MonoBehaviour
//{
//    public GameObject startButton;
//    public GameObject playAgainButton;
//    public Text winMessageText;
//    public GameObject ball;

//    public GameObject paddle1;  // Assign the first paddle in the Inspector
//    public GameObject paddle2;  // Assign the second paddle in the Inspector

//    public GameObject capsule1;  // Assign the first capsule in the Inspector
//    public GameObject capsule2;  // Assign the second capsule in the Inspector

//    public GameObject wall1;
//    public GameObject wall2;
//    public GameObject wall3;
//    public GameObject wall4;

//    public Text player1ScoreText;
//    public Text player2ScoreText;

//    private Vector3 paddle1StartPosition;
//    private Vector3 paddle2StartPosition;
//    private Vector3 paddle1StartScale;
//    private Vector3 paddle2StartScale;
//    private Vector3 capsule1StartPosition;
//    private Vector3 capsule2StartPosition;

//    private int player1Score = 0;
//    private int player2Score = 0;

//    private void Start()
//    {
//        // Ensure StartButton, PlayAgainButton, and WinMessageText are assigned
//        if (startButton == null || playAgainButton == null || winMessageText == null)
//        {
//            Debug.LogError("Start Button, Play Again Button, or Win Message Text is not assigned in the Inspector.");
//            return;
//        }

//        // Store initial positions and scales of paddles and capsules at the start of the game
//        if (paddle1 != null)
//        {
//            paddle1StartPosition = paddle1.transform.position;
//            paddle1StartScale = paddle1.transform.localScale;  // Store initial scale of paddle1
//        }

//        if (paddle2 != null)
//        {
//            paddle2StartPosition = paddle2.transform.position;
//            paddle2StartScale = paddle2.transform.localScale;  // Store initial scale of paddle2
//        }

//        if (capsule1 != null)
//        {
//            capsule1StartPosition = capsule1.transform.position;  // Store initial position of capsule1
//        }

//        if (capsule2 != null)
//        {
//            capsule2StartPosition = capsule2.transform.position;  // Store initial position of capsule2
//        }

//        // Show the start button at the beginning of the game
//        ShowStartButton();
//    }

//    private void ShowStartButton()
//    {
//        startButton.SetActive(true);
//        playAgainButton.SetActive(false);
//        winMessageText.gameObject.SetActive(false);
//        Time.timeScale = 0f;
//    }

//    private void StartGame()
//    {
//        startButton.SetActive(false);
//        playAgainButton.SetActive(false);
//        winMessageText.gameObject.SetActive(false);
//        Time.timeScale = 1f;

//        // Reset paddles and ball
//        ResetBallAndPaddles();

//        // If you have any other logic for resetting the paddles, you can include that here,
//        // otherwise, this block for glow activation can be removed as it's no longer needed.
//    }

//    public void ResetGame()
//    {
//        // Reset the scores, paddles, ball, and capsules
//        GameManager.Instance.ResetGame();

//        // Hide the play again button and win message
//        playAgainButton.SetActive(false);
//        winMessageText.text = "";
//        winMessageText.gameObject.SetActive(false);

//        // Reset score UI
//        UpdateScoreUI(1, 0);
//        UpdateScoreUI(2, 0);

//        // Reset ball, paddles, and walls
//        ResetBallAndPaddles();
//        ResetCapsules();
//        ResetWalls();

//        // Resume the game
//        Time.timeScale = 1f;
//    }

//    private void ResetBallAndPaddles()
//    {
//        Color paddleEmissionColor = new Color(1f, 0.75f, 0.8f); // Light pink color
//        float emissionIntensity = 2f;  // Adjust the emission intensity

//        // Reset paddle1 size, position, and set light pink glow effect
//        if (paddle1 != null)
//        {
//            paddle1.transform.position = paddle1StartPosition;
//            paddle1.transform.localScale = paddle1StartScale;  // Reset paddle size to original
//            PaddleController paddleController1 = paddle1.GetComponent<PaddleController>();
//            if (paddleController1 != null)
//            {
//                paddleController1.ResetPaddleSize();  // Ensure paddle behavior is reset
//            }

//            // Apply the emission glow to paddle1
//            Renderer paddle1Renderer = paddle1.GetComponent<Renderer>();
//            if (paddle1Renderer != null)
//            {
//                paddle1Renderer.material.SetColor("_EmissionColor", paddleEmissionColor * emissionIntensity);  // Set HDR light pink glow
//                paddle1Renderer.material.EnableKeyword("_EMISSION");  // Ensure emission is enabled
//            }
//        }

//        // Reset paddle2 size, position, and set light pink glow effect
//        if (paddle2 != null)
//        {
//            paddle2.transform.position = paddle2StartPosition;
//            paddle2.transform.localScale = paddle2StartScale;  // Reset paddle size to original
//            PaddleController paddleController2 = paddle2.GetComponent<PaddleController>();
//            if (paddleController2 != null)
//            {
//                paddleController2.ResetPaddleSize();  // Ensure paddle behavior is reset
//            }

//            // Apply the emission glow to paddle2
//            Renderer paddle2Renderer = paddle2.GetComponent<Renderer>();
//            if (paddle2Renderer != null)
//            {
//                paddle2Renderer.material.SetColor("_EmissionColor", paddleEmissionColor * emissionIntensity);  // Set HDR light pink glow
//                paddle2Renderer.material.EnableKeyword("_EMISSION");  // Ensure emission is enabled
//            }
//        }
//    }


//    //private void ResetWalls()
//    //{
//    //    Color emissionColor = Color.magenta; // Change this to the HDR color you want

//    //    if (wall1 != null)
//    //    {
//    //        wall1.SetActive(true);  // Ensure wall1 is active and visible
//    //        Renderer wall1Renderer = wall1.GetComponent<Renderer>();
//    //        if (wall1Renderer != null)
//    //        {
//    //            wall1Renderer.enabled = true;  // Make sure the wall is visible
//    //                                           // Set the emission color
//    //            wall1Renderer.material.SetColor("_EmissionColor", lightGreenColor * emissionIntensity);  // Set HDR light green glow
//    //            wall1Renderer.material.EnableKeyword("_EMISSION");  // Ensure emission is enabled
//    //        }
//    //    }

//    //    if (wall2 != null)
//    //    {
//    //        wall2.SetActive(true);
//    //        Renderer wall2Renderer = wall2.GetComponent<Renderer>();
//    //        if (wall2Renderer != null)
//    //        {
//    //            wall2Renderer.enabled = true;
//    //            wall2Renderer.material.SetColor("_EmissionColor", emissionColor * 2f); // Adjust intensity
//    //            wall2Renderer.material.EnableKeyword("_EMISSION");
//    //        }
//    //    }

//    //    if (wall3 != null)
//    //    {
//    //        wall3.SetActive(true);
//    //        Renderer wall3Renderer = wall3.GetComponent<Renderer>();
//    //        if (wall3Renderer != null)
//    //        {
//    //            wall3Renderer.enabled = true;
//    //            wall3Renderer.material.SetColor("_EmissionColor", emissionColor * 2f); // Adjust intensity
//    //            wall3Renderer.material.EnableKeyword("_EMISSION");
//    //        }
//    //    }

//    //    if (wall4 != null)
//    //    {
//    //        wall4.SetActive(true);
//    //        Renderer wall4Renderer = wall4.GetComponent<Renderer>();
//    //        if (wall4Renderer != null)
//    //        {
//    //            wall4Renderer.enabled = true;
//    //            wall4Renderer.material.SetColor("_EmissionColor", emissionColor * 2f); // Adjust intensity
//    //            wall4Renderer.material.EnableKeyword("_EMISSION");
//    //        }
//    //    }
//    //}

//    private void ResetWalls()
//    {
//        float emissionIntensity = 2f;  // Adjust the emission intensity
//        Color lightGreenColor = new Color(0.5f, 1f, 0.5f);  // Light green color

//        // Create an instance of the material for each wall to avoid shared material resetting
//        if (wall1 != null)
//        {
//            wall1.SetActive(true);
//            Renderer wall1Renderer = wall1.GetComponent<Renderer>();
//            if (wall1Renderer != null)
//            {
//                // Use a material instance
//                Material wall1Material = new Material(wall1Renderer.material);
//                wall1Material.SetColor("_EmissionColor", lightGreenColor * emissionIntensity);
//                wall1Material.EnableKeyword("_EMISSION");  // Ensure emission is enabled
//                wall1Renderer.material = wall1Material;  // Assign the new material instance
//            }
//        }

//        // Repeat the same process for wall2, wall3, and wall4
//        if (wall2 != null)
//        {
//            wall2.SetActive(true);
//            Renderer wall2Renderer = wall2.GetComponent<Renderer>();
//            if (wall2Renderer != null)
//            {
//                Material wall2Material = new Material(wall2Renderer.material);
//                wall2Material.SetColor("_EmissionColor", lightGreenColor * emissionIntensity);
//                wall2Material.EnableKeyword("_EMISSION");
//                wall2Renderer.material = wall2Material;
//            }
//        }

//        if (wall3 != null)
//        {
//            wall3.SetActive(true);
//            Renderer wall3Renderer = wall3.GetComponent<Renderer>();
//            if (wall3Renderer != null)
//            {
//                Material wall3Material = new Material(wall3Renderer.material);
//                wall3Material.SetColor("_EmissionColor", lightGreenColor * emissionIntensity);
//                wall3Material.EnableKeyword("_EMISSION");
//                wall3Renderer.material = wall3Material;
//            }
//        }

//        if (wall4 != null)
//        {
//            wall4.SetActive(true);
//            Renderer wall4Renderer = wall4.GetComponent<Renderer>();
//            if (wall4Renderer != null)
//            {
//                Material wall4Material = new Material(wall4Renderer.material);
//                wall4Material.SetColor("_EmissionColor", lightGreenColor * emissionIntensity);
//                wall4Material.EnableKeyword("_EMISSION");
//                wall4Renderer.material = wall4Material;
//            }
//        }
//    }

//    private void ResetCapsules()
//    {
//        // Reset capsule1 to its initial position, but keep it active
//        if (capsule1 != null)
//        {
//            CapsuleController capsuleController1 = capsule1.GetComponent<CapsuleController>();
//            if (capsuleController1 != null)
//            {
//                capsule1.transform.position = capsuleController1.GetInitialPosition();  // Reset to the initial position
//            }
//        }

//        // Reset capsule2 to its initial position, but keep it active
//        if (capsule2 != null)
//        {
//            CapsuleController capsuleController2 = capsule2.GetComponent<CapsuleController>();
//            if (capsuleController2 != null)
//            {
//                capsule2.transform.position = capsuleController2.GetInitialPosition();  // Reset to the initial position
//            }
//        }
//    }


//    public void UpdateScoreUI(int playerIndex, int score)
//    {
//        if (playerIndex == 1)
//        {
//            player1ScoreText.text = score.ToString();
//        }
//        else if (playerIndex == 2)
//        {
//            player2ScoreText.text = score.ToString();
//        }
//    }

//    public void GameOver(string winnerMessage)
//    {
//        playAgainButton.SetActive(true);
//        winMessageText.gameObject.SetActive(true);
//        winMessageText.text = winnerMessage;
//        Time.timeScale = 0f;
//    }

//    public void AddScore(int playerIndex)
//    {
//        if (playerIndex == 1)
//        {
//            player1Score++;
//            UpdateScoreUI(1, player1Score);
//        }
//        else if (playerIndex == 2)
//        {
//            player2Score++;
//            UpdateScoreUI(2, player2Score);
//        }
//    }

//}

using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject startButton;
    public GameObject playAgainButton;
    public Text winMessageText;
    public GameObject ball;

    public Text player1ScoreText;
    public Text player2ScoreText;

    public GameObject capsule1; // Reference to the first capsule
    public GameObject capsule2; // Reference to the second capsule

    public GameObject leftPaddle;  // Reference to the left paddle
    public GameObject rightPaddle; // Reference to the right paddle

    // Declare player scores
    private int player1Score = 0;
    private int player2Score = 0;

    // Define the initial positions
    private Vector3 leftPaddleOriginalSize;
    private Vector3 rightPaddleOriginalSize;

    private TrailRenderer ballTrail; // Reference to the Ball's Trail Renderer



    private void Start()
    {
        // Store the original sizes of the paddles
        leftPaddleOriginalSize = leftPaddle.transform.localScale;
        rightPaddleOriginalSize = rightPaddle.transform.localScale;
        ballTrail = ball.GetComponent<TrailRenderer>();


        ShowStartButton();

        if (leftPaddle == null || rightPaddle == null || capsule1 == null || capsule2 == null)
        {
            Debug.LogError("One or more paddle or capsule references are not assigned in the Inspector.");
        }

    }

    private void ShowStartButton()
    {
        startButton.SetActive(true);
        playAgainButton.SetActive(false);
        winMessageText.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        playAgainButton.SetActive(false);
        winMessageText.gameObject.SetActive(false);
        Time.timeScale = 1f;

        // Reset the scores when the game starts
        ResetScores();

        ResetBallAndPaddlesAndCapsules();

    }

    private void ResetScores()
    {
        GameManager.Instance.ResetGame();
        UpdateScoreUI();
    }

    // Reset the scores to zero
    //private void ResetScores()
    //{
    //    player1Score = 0;
    //    player2Score = 0;
    //    UpdateScoreUI(1, player1Score);
    //    UpdateScoreUI(2, player2Score);
    //}

    private void UpdateScoreUI()
    {
        player1ScoreText.text = GameManager.Instance.player1Score.ToString();
        player2ScoreText.text = GameManager.Instance.player2Score.ToString();
    }

    ////// Update the score UI based on the player index
    ////public void UpdateScoreUI(int playerIndex, int score)
    ////{
    ////    if (playerIndex == 1)
    ////    {
    ////        player1ScoreText.text = score.ToString();
    ////    }
    ////    else if (playerIndex == 2)
    ////    {
    ////        player2ScoreText.text = score.ToString();
    ////    }
    ////}

    public void AddScore(int playerIndex)
    {
        GameManager.Instance.AddScore(playerIndex);
        UpdateScoreUI();
    }


    ////public void AddScore(int playerIndex)
    ////{
    ////    if (playerIndex == 1)
    ////    {
    ////        player1Score++;
    ////        UpdateScoreUI(1, player1Score);
    ////    }
    ////    else if (playerIndex == 2)
    ////    {
    ////        player2Score++;
    ////        UpdateScoreUI(2, player2Score);
    ////    }
    ////}


   

    //// Call this when the game is over

    //// Method to update the score when a player scores
    //public void AddScore(int playerIndex)
    //{
    //    if (playerIndex == 1)
    //    {
    //        player1Score++;
    //        UpdateScoreUI(1, player1Score);
    //        CheckForWinner();  // Check if Player 1 has won
    //    }
    //    else if (playerIndex == 2)
    //    {
    //        player2Score++;
    //        UpdateScoreUI(2, player2Score);
    //        CheckForWinner();  // Check if Player 1 has won

    //    }
    //}

    //private void CheckForWinner()
    //{
    //    // Define the winning score
    //    int winningScore = 5;  // You can change this value as needed

    //    if (player1Score >= winningScore)
    //    {
    //        GameOver("Player 1 Wins!");
    //    }
    //    else if (player2Score >= winningScore)
    //    {

    //        GameOver("Player 2 Wins!");

    //    }
    //}

    // Method to update the score UI
    public void UpdateScoreUI(int playerIndex, int score)
    {
        if (playerIndex == 1)
        {
            player1ScoreText.text = score.ToString();
        }
        else if (playerIndex == 2)
        {
            player2ScoreText.text = score.ToString();
        }
    }
    public void GameOver(string winnerMessage)
    {
        playAgainButton.SetActive(true);
        winMessageText.gameObject.SetActive(true);
        winMessageText.text = winnerMessage;
        Time.timeScale = 0f;
    }

    public void ResetGame()
    {
        // Reset scores
        player1Score = 0;
        player2Score = 0;

        // Update the score UI
        UpdateScoreUI(1, player1Score);
        UpdateScoreUI(2, player2Score);

        // Reset the ball and paddles
        ResetBallAndPaddlesAndCapsules();
    }

    //private void ResetBallAndPaddlesAndCapsulls()
    //{
    //    // Reset the ball's position to the center of the game
    //    if (ball != null)
    //    {
    //        ball.transform.position = Vector3.zero; // Move the ball to the center
    //        ball.GetComponent<BallController>().StartBall(); // Start the ball's movement
    //    }

    //    // Reset paddle positions
    //    if (leftPaddle != null)
    //    {
    //        leftPaddle.transform.position = new Vector3(leftPaddle.transform.position.x, 0f, leftPaddle.transform.position.z); // Adjust Y to your desired position
    //    }

    //    if (rightPaddle != null)
    //    {
    //        rightPaddle.transform.position = new Vector3(rightPaddle.transform.position.x, 0f, rightPaddle.transform.position.z); // Adjust Y to your desired position
    //    }

    //    // Reset the position of the capsules (assuming you have two capsules)
    //    // Assuming you have references to the capsules in your GameController
    //    if (capsule1 != null)
    //    {
    //        capsule1.transform.position = new Vector3(capsule1.transform.position.x, 1f, capsule1.transform.position.z); // Set the desired Y position
    //    }

    //    if (capsule2 != null)
    //    {
    //        capsule2.transform.position = new Vector3(capsule2.transform.position.x, 1f, capsule2.transform.position.z); // Set the desired Y position
    //    }
    //}

    //private void ResetBallAndPaddlesAndCapsules()
    //{
    //    // Reset the ball's position to the center of the game
    //    if (ball != null)
    //    {
    //        ball.transform.position = ballInitialPosition; // Move the ball to the initial position
    //        ball.GetComponent<BallController>().StartBall(); // Start the ball's movement
    //    }

    //    // Reset paddle positions
    //    if (leftPaddle != null)
    //    {
    //        leftPaddle.transform.position = leftPaddleInitialPosition; // Adjust Y to your desired position
    //    }

    //    if (rightPaddle != null)
    //    {
    //        rightPaddle.transform.position = rightPaddleInitialPosition; // Adjust Y to your desired position
    //    }

    //    // Reset the position of the capsules
    //    if (capsule1 != null)
    //    {
    //        capsule1.transform.position = capsule1InitialPosition; // Set the desired position
    //    }

    //    if (capsule2 != null)
    //    {
    //        capsule2.transform.position = capsule2InitialPosition; // Set the desired position
    //    }
    //}

    private void ResetBallAndPaddlesAndCapsules()
    {
        Debug.Log("Resetting ball and paddles");

        if (ball != null)
        {
            Debug.Log("Resetting ball position");
            ball.transform.position = new Vector3(0, 0, 0);
            ball.GetComponent<BallController>().StartBall();

            // Reset the ball's trail
            if (ballTrail != null)
            {
                ballTrail.Clear(); // Clear the trail
            }
        }

        if (leftPaddle != null)
        {
            Debug.Log("Resetting left paddle position");
            leftPaddle.transform.position = new Vector3(-12, 0, 0);
            leftPaddle.transform.localScale = leftPaddleOriginalSize; // Reset to original size

        }

        if (rightPaddle != null)
        {
            Debug.Log("Resetting right paddle position");
            rightPaddle.transform.position = new Vector3(12, 0, 0);
            rightPaddle.transform.localScale = rightPaddleOriginalSize; // Reset to original size

        }

        if (capsule1 != null)
        {
            Debug.Log("Resetting capsule 1 position");
            capsule1.transform.position = new Vector3(-5, 1, 0);
        }

        if (capsule2 != null)
        {
            Debug.Log("Resetting capsule 2 position");
            capsule2.transform.position = new Vector3(5, 1, 0);
        }
    }

    



}
