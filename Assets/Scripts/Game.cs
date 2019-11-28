using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] private PlatformerCharacter2D player1;
    [SerializeField] private Transform playerSpawnPoint1;
    

    [SerializeField] private PlatformerCharacter2D player2;
    [SerializeField] private Transform playerSpawnPoint2;

    [SerializeField]
    private TextMeshProUGUI livesText1;

    [SerializeField]
    private TextMeshProUGUI livesText2;

    [SerializeField] private Spawner[] spawners;

    private void Start()
    {
        UpdateHUD();
    }

    IEnumerator EndScreen(int player)
    {
        yield return new WaitForSeconds(1);

        if(player == 1) { SceneManager.LoadScene(3); }
        else if (player == 2) { SceneManager.LoadScene(2); }
    }

    public void EndGame(int player)
    {
        StartCoroutine(EndScreen(player));
    }

    public void UpdateHUD()
    {
        livesText1.text = "" + player1.lives;
        livesText2.text = "" + player2.lives;
    }

}
