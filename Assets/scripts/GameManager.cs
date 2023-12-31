using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using webserver;

public class GameManager : MonoBehaviour
{
    public GameObject startGame;
    public GameObject fillInInitials;
    public TMP_Text displayScore;
    private static bool playing;
    private bool prepared = true;

    private float score;
    public delegate void ResetGame();
    private static ResetGame resetGame;

    private TMP_InputField inputField;

    private void Start()
    {
        resetGame += GameReset;
        inputField = fillInInitials.GetComponentInChildren<TMP_InputField>();
    }

    private void Update()
    {
        if (playing)
        {
            score += 10 * Time.deltaTime;
            displayScore.text = (int) score + "";
        }
        if (Input.GetKeyDown(KeyCode.Space) && !playing && prepared)
        {
            PlayerStart();
            startGame.SetActive(false);
            prepared = false;
        }

        if (Input.GetKeyDown(KeyCode.Return) && !playing && !prepared)
        {
            var initials = inputField.text;
            if (initials.Length == 3)
            {
                SetPlayerResult(initials);
            }
        }
    }

    private void GameReset()
    {
        startGame.SetActive(true);
        inputField.text = "";
        fillInInitials.SetActive(false);
        score = 0;
    }

    public void PlayerDeath()
    {
        playing = false;
        fillInInitials.SetActive(true);
    }

    private void PlayerStart()
    {
        playing = true;
    }

    private void SetPlayerResult(string initals)
    {
        StartCoroutine(WebConnector.SendPostRequest(inputField.text,(int) score));
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
