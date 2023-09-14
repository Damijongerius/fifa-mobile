using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> floorObjects = new List<GameObject>();
    public List<GameObject> floatingObjects = new List<GameObject>();

    private float minSpawnInterval = 2.0f;
    private float maxSpawnInterval = 5.0f;

    private float nextSpawnTime;

    private void Start()
    {
        // Set the initial time to spawn an object
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        // Check if it's time to spawn an object
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            // Update the next spawn time with a new random interval
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    private void SpawnObject()
    {
        int number = Random.Range(0, floorObjects.Count + floatingObjects.Count);
        List<GameObject> mergedobjects = floorObjects;
        mergedobjects.AddRange(floatingObjects);
        if(number < floorObjects.Count)
        {
            Instantiate(mergedobjects[number], transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(mergedobjects[number], transform.position, Quaternion.identity);
        }
    }
}
