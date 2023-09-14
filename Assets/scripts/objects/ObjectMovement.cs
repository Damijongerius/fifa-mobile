using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * 5 * Time.deltaTime;
    }
}
