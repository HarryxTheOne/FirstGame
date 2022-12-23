using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    public GameObject enemyPrefab; // the enemy prefab that you want to spawn
    public float spawnDelay = 1f; // the delay between each spawn
    public float spawnDistance = 10f; // the distance from the camera at which the enemy will spawn

    // Update is called once per frame
    void Update()
    {
        // check if it's time to spawn the next enemy
        if (Time.time >= nextSpawnTime)
        {
            // spawn the enemy
            SpawnEnemy();

            // set the next spawn time
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    void SpawnEnemy()
    {
        // choose a random side to spawn the enemy on
        int side = Random.Range(0, 3);

        // create a position off screen to spawn the enemy at
        Vector3 enemyPosition = Vector3.zero;
        switch (side)
        {
            case 0: // spawn on the left
                enemyPosition = new Vector3(-spawnDistance, Random.Range(-spawnDistance, spawnDistance), 0f);
                break;
            case 1: // spawn on the right
                enemyPosition = new Vector3(spawnDistance, Random.Range(-spawnDistance, spawnDistance), 0f);
                break;
            case 2: // spawn on the top
                enemyPosition = new Vector3(Random.Range(-spawnDistance, spawnDistance), spawnDistance, 0f);
                break;
            case 3: // spawn on the bottom
                enemyPosition = new Vector3(Random.Range(-spawnDistance, spawnDistance), -spawnDistance, 0f);
                break;
        }

        // instantiate the enemy at the chosen position
        GameObject enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
    }

    private float nextSpawnTime = 0f; // the time of the next enemy spawn
}
