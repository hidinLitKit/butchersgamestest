using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameEvents
{
    public static Action onGameStart;
    public static Action onWin;
    public static Action onLose;
    public static Action<float, float> onChangeScore;

    public static void GameStart()
    {
        onGameStart?.Invoke();
    }
    public static void Win()
    {
        onWin?.Invoke();
    }
    public static void Lose()
    {
        onLose?.Invoke();
    }
    public static void ChangeScore(float value, float maxValue)
    {
        onChangeScore?.Invoke(value, maxValue);
    }
}
