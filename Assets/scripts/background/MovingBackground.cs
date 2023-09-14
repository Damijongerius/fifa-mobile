using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingBackground : MonoBehaviour
{
    public Material material;
    private Vector2 offset;

    void Update()
    {
        offset += new Vector2(Time.deltaTime * 0.5f, 0);


        material.mainTextureOffset = offset;
    }
}
