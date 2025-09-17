using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Display : MonoBehaviour
{
    public int playerHealth;
    public Text HealthText;
    public int playerScore;
    public Text ScoreText;
    public int keys;
    public Text KeyText;
    public GameObject gameOverScreen;
    public GameObject player;

    void Update()
    {
        HealthText.text = player.GetComponent<Health>().currentHealth.ToString();
        ScoreText.text = FindObjectOfType<Score>().score.ToString();
        KeyText.text = player.GetComponent<PlayerPickup>().keys.ToString();
    }

    //Run function manually in 3dots icon on script in Unity
    //[ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        ScoreText.text = playerScore.ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOverScreen.SetActive(true);
    }
}
