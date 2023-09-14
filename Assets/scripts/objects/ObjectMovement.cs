using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed;
    public float minSpeed;
    // Update is called once per frame
    void Update()
    {
        float rand = speed;
        if(minSpeed != 0)
        {
            rand = Random.Range(minSpeed, speed);
        }
       
        transform.position += Vector3.left * rand * Time.deltaTime;

        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

}
