using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public GameObject startGame;
    public GameObject fillInInitials;
    
    private static bool playing;
    private bool prepared = true;

    private float score;
    public delegate void ResetGame();
    private static ResetGame resetGame;

    private TMP_InputField inputField;

    private void Start()
    {
        inputField = fillInInitials.GetComponent<TMP_InputField>();
    }

    private void Update()
    {
        if (playing)
        {
            score += 1 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !playing && prepared)
        {
            PlayerStart();
            startGame.SetActive(false);
            prepared = false;
        }

        if (Input.GetKeyDown(KeyCode.Return) && !playing && !prepared)
        {
            string initials = inputField.text;
            if (initials.Length == 3)
            {
                SetPlayerResult(initials);
            }
        }
    }

    public void PlayerDeath()
    {
        playing = false;
        fillInInitials.SetActive(true);
    }

    public void PlayerStart()
    {
        playing = true;
    }

    public void SetPlayerResult(string initals)
    {
        Debug.Log(initals + "score:" + Mathf.RoundToInt(score));
        //send this data to server
        
        resetGame();
        prepared = true;
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
