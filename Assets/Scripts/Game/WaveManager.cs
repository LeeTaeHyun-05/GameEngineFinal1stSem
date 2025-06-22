using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [System.Serializable]
    public class wave
    {
        public GameObject enemyPrefab;
        public int spawnCount;
        public float spawninterval;
    }

    [Header("Wave Settings")]
    public List<wave> waves;
    public Transform[] spawnPoints;

    private int currentWaveIndex = 0;
    private bool isSpawning = false;

    private void Start()
    {
        StartCoroutine(SpawnWaveRoutine());
    }

    private IEnumerator SpawnWaveRoutine()
    {
        yield return new WaitForSeconds(2f);
        
        while (currentWaveIndex < waves.Count)
        {
            isSpawning = true;
            wave currentWave = waves[currentWaveIndex];

            for (int i = 0; i < currentWave.spawnCount; i++)
            {
                SpawnEnemy(currentWave.enemyPrefab);
                yield return new WaitForSeconds(currentWave.spawninterval);
            }

            isSpawning = false;
            currentWaveIndex++;

            yield return new WaitForSeconds(5f);
        }

        Debug.Log("모든 웨이브 완료");
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        int index = Random.Range(0,spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];

        Instantiate(enemyPrefab, spawnPoint.position,Quaternion.identity);
    }
}
