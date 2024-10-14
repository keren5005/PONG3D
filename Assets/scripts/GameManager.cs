using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int player1Score = 0;
    public int player2Score = 0;
    public int maxScore = 5;  // The score required to win the game

    public PaddleController player1Paddle;  // Reference to Player 1's paddle
    public PaddleController player2Paddle;  // Reference to Player 2's paddle

    private AudioSource audioSource;
    public AudioClip scoreSound;
    public AudioClip winSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing from GameManager!");
        }
    }

    public void ResetGame()
    {
        player1Score = 0;
        player2Score = 0;

        player1Paddle.ResetPaddleSize();
        player2Paddle.ResetPaddleSize();
    }

    public void AddScore(int playerIndex)
    {
        StartCoroutine(ScoreWithDelay(playerIndex));
    }

   
    private IEnumerator ScoreWithDelay(int playerIndex)
    {
        if (playerIndex == 1)
        {
            player1Score++;
            FindObjectOfType<GameController>().UpdateScoreUI(1, player1Score);
            player1Paddle.DecreasePaddleSize();  // Decrease Player 1's paddle size when they score
        }
        else if (playerIndex == 2)
        {
            player2Score++;
            FindObjectOfType<GameController>().UpdateScoreUI(2, player2Score);
            player2Paddle.DecreasePaddleSize();  // Decrease Player 2's paddle size when they score
        }

        if (audioSource != null && scoreSound != null)
        {
            audioSource.PlayOneShot(scoreSound);
        }

        yield return new WaitForSeconds(0.5f);
        CheckForWin();
    }

    private void CheckForWin()
    {
        if (player1Score >= maxScore)
        {
            PlayWinningSound();
            FindObjectOfType<GameController>().GameOver("Player 1 Wins!");
        }
        else if (player2Score >= maxScore)
        {
            PlayWinningSound();
            FindObjectOfType<GameController>().GameOver("Player 2 Wins!");
        }
    }

    private void PlayWinningSound()
    {
        if (audioSource != null && winSound != null)
        {
            audioSource.PlayOneShot(winSound);
        }
    }
}
