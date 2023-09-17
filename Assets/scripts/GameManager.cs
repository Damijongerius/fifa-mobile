using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool playing;

    public delegate void ResetGame();
    private static ResetGame resetGame;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !playing)
        {
            
        }
    }

    public static void PlayerDeath()
    {
        playing = false;
    }

    public static void PlayerStart()
    {
        playing = true;
    }

    public static void SetPlayerResult(int score, string name)
    {
        resetGame();
        //send this data to server
    }

    // Subscribe a method to the gameChange delegate
    public static void SubscribeToDelegate(ResetGame method)
    {
        resetGame += method;
    }

    // Unsubscribe a method from the gameChange delegate
    public static void UnsubscribeFromDelegate(ResetGame method)
    {
        resetGame -= method;
    }

    public static bool Playing()
    {
        return playing;
    }
}
