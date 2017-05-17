using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;

    private int score;

    public void Start()
    {
        StartCoroutine(SpawnWaves());

        score = 0;
        UpdateScore();

        gameOver = false;
        restart = false;

        restartText.text = "";
        gameOverText.text = "";
    }

    public void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while(!gameOver)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                SpawnHazard();

                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
        }

        restartText.text = "Press 'R' for Restart";
        restart = true;
    }

    private void SpawnHazard()
    {
        GameObject hazard = hazards[Random.Range(0, hazards.Length)];

        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnValues.x, spawnValues.x),
            spawnValues.y,
            spawnValues.z
        );

        Quaternion spawnRotation = hazard.transform.rotation;

        Instantiate(hazard, spawnPosition, spawnRotation);
    }

    public void AddScore(int value)
    {
        score += value;

        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
