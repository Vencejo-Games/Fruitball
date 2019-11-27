using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] private Player player1;
    [SerializeField] private Transform playerSpawnPoint1;
    public int lives1;

    [SerializeField] private Player player2;
    [SerializeField] private Transform playerSpawnPoint2;
    public int lives2;

    [SerializeField]
    private TextMeshProUGUI scoreText1, livesText1, bestText1;

    [SerializeField]
    private TextMeshProUGUI scoreText2, livesText2, bestText2;

    [SerializeField] private Spawner[] spawners;

    private int level;

    //public int score, highscore;

    private void Start()
    {
        //highscore = PlayerPrefs.GetInt("Highscore", 0);
        //Load();
        //bestText.text = "Best: " + highscore;
        UpdateHUD();
    }

    public void LoseLife(int player)
    {
        if (player == 1)
        {
            if (lives1 > 0)
            {
                // respawn our player
                // deduct life
                StartCoroutine(Respawn1());
            }
            /*
            else
            {
                // end the game
                EndGame();
            }
            */
        }
        else if (player == 2)
        {
            if (lives2 > 0)
            {
                // respawn our player
                // deduct life
                StartCoroutine(Respawn2());
            }
        }

        
    }

    // Respawn player with spawn delay
    IEnumerator Respawn1()
    {
        yield return new WaitForSeconds(2f);
        lives1--;
        Instantiate(player1.gameObject, playerSpawnPoint1.position, Quaternion.identity);
        // update HUD show new life count
        UpdateHUD();
    }

    // Respawn player with spawn delay
    IEnumerator Respawn2()
    {
        yield return new WaitForSeconds(2f);
        lives2--;
        Instantiate(player2.gameObject, playerSpawnPoint2.position, Quaternion.identity);
        // update HUD show new life count
        UpdateHUD();
    }

    // Called whenever an enemy is killed or coin collected
    public void AddPoints(int points)
    {
        //score += points;
        UpdateHUD();
        CheckForLevelCompletion();
    }

    public void AddLife(int player)
    {
        if (player == 1)
        {
            lives1++;
        }
        else if (player == 2)
        {
            lives2++;
        }


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
            //CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        Debug.Log("Complete Level");
        
        // increase level by 1
        // load the level
        level++;
        //Save();

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
        //PlayerPrefs.SetInt("Score", score);
        //PlayerPrefs.SetInt("Lives", lives);
        //PlayerPrefs.SetInt("Level", level);
    }

    private void Load()
    {
        //score = PlayerPrefs.GetInt("Score", 0);
        //lives = PlayerPrefs.GetInt("Lives", 3);
        //level = PlayerPrefs.GetInt("Level", 0);
    }

    void StartNewGame()
    {
        level = 0;
        SceneManager.LoadScene(level);
        //PlayerPrefs.DeleteKey("Score");
        //PlayerPrefs.DeleteKey("Lives");
        //PlayerPrefs.DeleteKey("Level");
    }

    void EndGame()
    {
        /*
        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        */
        StartNewGame();
    }

    void UpdateHUD()
    {
        //scoreText.text = "Score: " + score;
        livesText1.text = "Lives: " + lives1;
        livesText2.text = "Lives: " + lives2;
    }

}
