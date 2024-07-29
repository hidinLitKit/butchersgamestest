using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameEvents
{
    public static Action onWin;
    public static Action onLose;
    public static Action<float> onChangeScore;

    public static void Win()
    {
        onWin?.Invoke();
    }
    public static void Lose()
    {
        onLose?.Invoke();
    }
    public static void ChangeScore(float value)
    {
        onChangeScore?.Invoke(value);
    }
}
