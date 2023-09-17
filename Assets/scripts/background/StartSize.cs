using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSize : MonoBehaviour
{
    public float growSpeed;   // Speed at which the text grows
    public float shrinkSpeed; // Speed at which the text shrinks
    public float maxSize;    // Maximum font size
    public float minSize;    // Minimum font size

    private TextMesh textMesh;
    private float currentSize;
    private bool isGrowing = true;

    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        currentSize = textMesh.characterSize;
    }

    void Update()
    {
        // Check if we should grow or shrink
        if (isGrowing)
        {
            // Increase the font size
            currentSize += growSpeed * Time.deltaTime;
            // If we reached or exceeded the maximum size, switch to shrinking
            if (currentSize >= maxSize)
            {
                isGrowing = false;
            }
        }
        else
        {
            // Decrease the font size
            currentSize -= shrinkSpeed * Time.deltaTime;
            // If we reached or went below the minimum size, switch to growing
            if (currentSize <= minSize)
            {
                isGrowing = true;
            }
        }

        // Update the Text Mesh font size
        textMesh.characterSize = currentSize;
    }
}