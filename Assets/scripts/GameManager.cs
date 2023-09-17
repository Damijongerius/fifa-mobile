using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool playing;

    delegate void GameStop();
    GameStop gamestop;

    public static void PlayerDeath(int score, string name)
    {

    }

    public static void PlayerStart()
    {

    }
}
