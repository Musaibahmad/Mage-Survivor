using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 5f;
    private float timeSinceLastSpawn = 0f;
    int enemyCounter;

    void Update()
    {

        if (enemyCounter < 10)
        {
            if (Time.time - timeSinceLastSpawn > Random.Range(minSpawnInterval, maxSpawnInterval))
            {
                SpawnEnemy();
                timeSinceLastSpawn = Time.time;
            } 
        }
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned!");
            return;
        }

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        enemyCounter++;
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
