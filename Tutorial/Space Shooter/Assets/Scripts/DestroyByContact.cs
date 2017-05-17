using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    private int maxLife;
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

        maxLife = Random.Range(5, 10);
        life = maxLife;
    }

    void OnAsteroidHit()
    {
        Instantiate(explosion, transform.position, transform.rotation);

        life -= 1;

        gameController.AddScore(1);

        if (life <= 0)
        {
            OnAsteroidDestroyed();
        }
    }

    void OnAsteroidDestroyed()
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
        }

        // Hit bolt
        else if (other.CompareTag("bolt"))
        {
            OnAsteroidHit();
            Destroy(other.gameObject);
        }

        // Hit asteroid
        else if (other.CompareTag("hazard"))
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
