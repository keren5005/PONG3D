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

        ResetScores();

        ResetBallAndPaddlesAndCapsules();

        TrailRenderer trailRenderer = ball.GetComponent<TrailRenderer>();
        if (trailRenderer != null)
        {
            trailRenderer.enabled = true; // Enable the trail
        }

    }

    private void ResetScores()
    {
        GameManager.Instance.ResetGame();
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        player1ScoreText.text = GameManager.Instance.player1Score.ToString();
        player2ScoreText.text = GameManager.Instance.player2Score.ToString();
    }

    public void AddScore(int playerIndex)
    {
        GameManager.Instance.AddScore(playerIndex);
        UpdateScoreUI();
    }

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
        BallController ballController = ball.GetComponent<BallController>();
        if (ballController != null)
        {
            TrailRenderer trailRenderer = ball.GetComponent<TrailRenderer>();
            if (trailRenderer != null)
            {
                trailRenderer.enabled = false; // Disable the trail
            }
        }

        playAgainButton.SetActive(true);
        winMessageText.gameObject.SetActive(true);
        winMessageText.text = winnerMessage;
        Time.timeScale = 0f;
    }

    public void ResetGame()
    {
        player1Score = 0;
        player2Score = 0;

        UpdateScoreUI(1, player1Score);
        UpdateScoreUI(2, player2Score);

        ResetBallAndPaddlesAndCapsules();
    }

    private void ResetBallAndPaddlesAndCapsules()
    {
        Debug.Log("Resetting ball and paddles");

        if (ball != null)
        {
            Debug.Log("Resetting ball position");
            ball.transform.position = new Vector3(0, 0, 0);
            ball.GetComponent<BallController>().StartBall();

            if (ballTrail != null)
            {
                ballTrail.Clear();
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
