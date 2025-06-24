using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject[] normalEnemies;
    public GameObject strongEnemy;
    public Transform[] spawnPoints;

    [Header("Wave Settings")]
    public float waveInterval = 5f;
    public float spawnDelay = 0.5f;

    private int currentWave = 1;

    private void Start()
    {
        StartCoroutine(HandleWave());
    }

    private IEnumerator HandleWave()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            GameManager.Instance.SetWave(currentWave);

            int spawnCount = currentWave % 3 == 0 ? 11 : 10;
            int strongEnemySpawned = 0;

            for (int i = 0; i < spawnCount; i++)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                if (currentWave % 3 == 0 && strongEnemySpawned == 0)
                {
                    Instantiate(strongEnemy, spawnPoint.position, Quaternion.identity);
                    strongEnemySpawned++;
                }
                else
                {
                    GameObject enemyPrefab = normalEnemies[Random.Range(0, normalEnemies.Length)];
                    Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                }

                yield return new WaitForSeconds(spawnDelay);
            }

            currentWave++;
            yield return new WaitForSeconds(waveInterval);
        }
    }
}
