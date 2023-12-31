using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> floorObjects = new List<GameObject>();
    public List<GameObject> floatingObjects = new List<GameObject>();

    private float minSpawnInterval = 2.0f;
    private float maxSpawnInterval = 5.0f;

    public float maxIncrease = 1.9f;
    public float speedIncrease = 0;
    private float standardIncreaseSpeed = 0f;

    private float nextSpawnTime;

    private void Start()
    {
        GameManager.SubscribeToDelegate(ResetGame);
    }

    private void ResetGame()
    {
        // Set the initial time to spawn an object
        speedIncrease = standardIncreaseSpeed;
    }

    private void Update()
    {
        // Check if it's time to spawn an object
        if (Time.time >= nextSpawnTime && GameManager.Playing())
        {
            SpawnObject();
            // Update the next spawn time with a new random interval
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval - speedIncrease, maxSpawnInterval - speedIncrease);
            int random = Random.Range(0, 2);
            Debug.Log(random);
            if(random == 1)
            {
                speedIncrease += 0.1f;
            }
        }
    }

    private void SpawnObject()
    {
        List<GameObject> mergedobjects = new List<GameObject>();
        mergedobjects.AddRange(floorObjects);
        mergedobjects.AddRange(floatingObjects);

        int number = Random.Range(0, mergedobjects.Count);

        if(number < floorObjects.Count)
        {
            Instantiate(mergedobjects[number], transform.position, Quaternion.identity,transform);
        }
        else
        {
            Vector3 pos = transform.position + new Vector3(0,Random.Range(0.5f, 2f),0);
            Instantiate(mergedobjects[number], pos, Quaternion.identity, transform);
        }
    }
}
