using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Display : MonoBehaviour
{
    public int playerScore;
    public Text ScoreText;
    public int keys;
    public Text KeyText;
    public GameObject gameOverScreen;
    public GameObject player;

    //Run function manually in 3dots icon on script in Unity
    //[ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        ScoreText.text = playerScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
