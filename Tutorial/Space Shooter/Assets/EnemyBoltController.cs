using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoltController : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    
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
    }

    void OnTriggerEnter(Collider other)
    {
        // Hit Player
        if (other.CompareTag("player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

            gameController.GameOver();
        }

        // Hit hazard
        else if (other.CompareTag("hazard"))
        {
            //Destroy(gameObject);
        }
    }

}
