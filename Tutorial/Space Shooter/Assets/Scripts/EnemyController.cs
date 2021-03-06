﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public int maxLife;

    private int life;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        life = maxLife;
    }

    void OnHit()
    {
        Instantiate(explosion, transform.position, transform.rotation);

        life -= 1;

        gameController.AddScore(1);

        if (life <= 0)
        {
            OnDestroyed();
        }
    }

    void OnDestroyed()
    {
        Destroy(gameObject);

        gameController.AddScore(scoreValue);
    }

    void OnTriggerEnter(Collider other)
    {
        // Hit boundary
        if (other.CompareTag("boundary"))
        {
            return;
        }

        // Hit Player
        if (other.CompareTag("player"))
        {
            Destroy(other.gameObject);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

            gameController.GameOver();
        }

        // Hit bolt
        else if (other.CompareTag("bolt"))
        {
            OnHit();
            Destroy(other.gameObject);
        }

        // Hit hazard
        else if (other.CompareTag("hazard"))
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
