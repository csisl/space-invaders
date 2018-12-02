using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab; // enemy prefab we want to spawn
    public Transform enemyPrefab1;
    public Transform enemyPrefab2;
    public float timeBetweenWaves = 5f; // make longer after testing is done
                                        // how long it will take to spawn the first wave
    private float countdown = 2f;
    public static int waveNumber = 1;

    // reference to spawn location
    public Transform spawnPoint;

    public Text waveCountdownText;

	void Start(){
		waveNumber = 1;
	}

    void Update()
    {
        // manage time
        if (countdown <= 0f)
        {
            // begin spawning enemies
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        waveCountdownText.text = "Next wave: " + Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveNumber++;
    }

    void SpawnEnemy()
    {
        int x = Random.Range(1, 4);
        if (x == 1)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else if (x == 2)
        {
            Instantiate(enemyPrefab1, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
        }
    }

}
