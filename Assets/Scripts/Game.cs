using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private Spawner[] spawners;

    [SerializeField]
    private TextMeshProUGUI scoreText, livesText, bestText;

    private int level;

    public int lives, score, highscore;

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        Load();
        bestText.text = "Best: " + highscore;
        UpdateHUD();
    }

    public void LoseLife()
    {
        if (lives > 0)
        {
            // respawn our player
            // deduct life
            StartCoroutine(Respawn());
        }
        else
        {
            // end the game
            EndGame();
        }
    }

    // Respawn player with spawn delay
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);
        lives--;
        Instantiate(player.gameObject, playerSpawnPoint.position, Quaternion.identity);
        // update HUD show new life count
        UpdateHUD();
    }

    // Called whenever an enemy is killed or coin collected
    public void AddPoints(int points)
    {
        score += points;
        UpdateHUD();
        CheckForLevelCompletion();
    }

    public void AddLife()
    {
        lives++;
        UpdateHUD();
    }

    private void CheckForLevelCompletion()
    {
        if (!FindObjectOfType<Enemy>())
        {
            // no enemies are alive currently
            // spawner could still spawn enemies though
            foreach (Spawner spawner in spawners)
            {
                if (!spawner.completed)
                {
                    return;
                }
            }
            // complete level
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        Debug.Log("Complete Level");
        
        // increase level by 1
        // load the level
        level++;
        Save();

        if (level <= SceneManager.sceneCountInBuildSettings-1)
        {
            SceneManager.LoadScene(level);
        }
        else
        {
            Debug.Log("A WINNER IS YOU!");
            EndGame();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Lives", lives);
        PlayerPrefs.SetInt("Level", level);
    }

    private void Load()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        lives = PlayerPrefs.GetInt("Lives", 3);
        level = PlayerPrefs.GetInt("Level", 0);
    }

    void StartNewGame()
    {
        level = 0;
        SceneManager.LoadScene(level);
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Lives");
        PlayerPrefs.DeleteKey("Level");
    }

    void EndGame()
    {
        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        StartNewGame();
    }

    void UpdateHUD()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }

}
