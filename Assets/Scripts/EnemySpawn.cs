using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float yPosition = 1f;
    public float zPosition = 0f;

    public float spawnInterval = 5f;
    public int minEnemiesPerWave = 4;
    public int maxEnemiesPerWave = 8;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemies), 0f, spawnInterval);
    }

    void SpawnEnemies()
    {
        float cubeWidth = transform.localScale.x;
        Vector3 cubePosition = transform.position;

        int enemiesThisWave = Random.Range(minEnemiesPerWave, maxEnemiesPerWave + 1);

        for (int i = 0; i < enemiesThisWave; i++)
        {
            float randomX = Random.Range(-cubeWidth / 2f, cubeWidth / 2f);
            Vector3 spawnPos = new Vector3(cubePosition.x + randomX, yPosition, zPosition);

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}