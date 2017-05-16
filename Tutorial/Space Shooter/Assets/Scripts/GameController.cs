using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GUIText scoreText;

    private int score;

    public void Start()
    {
        StartCoroutine(SpawnWaves());

        score = 0;
        UpdateScore();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                SpawnHazard();

                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
        }
    }

    void SpawnHazard()
    {

        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnValues.x, spawnValues.x),
            spawnValues.y,
            spawnValues.z
        );

        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(hazard, spawnPosition, spawnRotation);
    }

    public void AddScore(int value)
    {
        score += value;

        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
