using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public static bool GameCompleted = false;

    public Wave[] waves;

    public Transform spawnPoint;
    
    public float timeBetweenwaves = 10f; 
    private float countdown = 2f;

    public Text waveCountdownText;
    private int waveIndex = 0;

    void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }

        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenwaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = "Next Wave in: " + string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
        {
            PlayerStats.Rounds++;

            Wave wave = waves[waveIndex];

            for (int i = 0; i < wave.amountOfEnemyToSpawn; i++)
            {
                SpawnEnemy(wave.enemyType);
                yield return new WaitForSeconds(1f / wave.spawnRate);
            }
            waveIndex++;

            if(waveIndex == waves.Length)
            {
                Debug.Log("GG, YOU WON THE GAME!");
                this.enabled = false;
                GameCompleted = true;
            }
        }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    } 
}
