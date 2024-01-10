using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform spawnArea;
    public float minSpawnDelay = 0.1f;
    public float maxSpawnDelay = 0.2f;
    public PlayManager playManager;

    private void Start()
    {
        if (!playManager.isGameOver)
        {
           StartCoroutine(SpawnObstacles());
        }
    }
    private void Update()
    {
        
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);

            Vector3 randomPosition = GetRandomPosition();

            Instantiate(obstaclePrefab, randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(spawnArea.position.x - 2, spawnArea.position.x + 2);
        float randomY = Random.Range(0, 1);
        float randomZ = Random.Range(spawnArea.position.z + 20, spawnArea.position.z + 30);

        return new Vector3(randomX, randomY, randomZ);
    }
}