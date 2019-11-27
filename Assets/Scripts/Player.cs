﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Game game;
    
    private void Awake()
    {
        game = FindObjectOfType<Game>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Hurt();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                StartCoroutine(HurtEnemy(collision.gameObject.GetComponent<Enemy>()));
                break;
            case "Gem":
                game.AddLife();
                Destroy(collision.gameObject);
                break;
            case "Coin":
                game.AddPoints(100);
                Destroy(collision.gameObject);
                break;
            default:
                break;
        }
    }

    IEnumerator HurtEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
        yield return new WaitForEndOfFrame();
        // add points to game based on enemy point value
        game.AddPoints(enemy.pointValue);
        // add points will check to see if any enemies exist, complete level?
    }

    void Hurt()
    {
        // lose life
        game.LoseLife();
        Destroy(this.gameObject);
    }
}
