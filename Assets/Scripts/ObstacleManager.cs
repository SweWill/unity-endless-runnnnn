using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;  // the obstacle prefab that will be spawned
    public float minX;  // the minimum X position for the spawn position
    public float maxX;  // the maximum X position for the spawn position
    public float minY;  // the minimum Y position for the spawn position
    public float maxY;  // the maximum Y position for the spawn position
    public float timeBetweenSpawns;  // the time in seconds between each obstacle spawn

    private IEnumerator Start()
    {
        while (true)  // loop infinitely
        {
            float randomX = Random.Range(minX, maxX);  // generate a random X position within the specified range
            float randomY = Random.Range(minY, maxY);  // generate a random Y position within the specified range
            Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, 0);  // calculate the spawn position relative to this object's position
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);  // spawn the obstacle at the calculated position

            yield return new WaitForSeconds(timeBetweenSpawns);  // wait for the specified time before spawning the next obstacle
        }
    }
}
