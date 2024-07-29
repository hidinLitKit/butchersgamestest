using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ButchersGames;
public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private void OnEnable()
    {
        GameEvents.onChangeScore += SetScore;
        LevelManager.Default.OnLevelStarted += SetLevel;
    }
    private void OnDisable()
    {
        GameEvents.onChangeScore -= SetScore;
        LevelManager.Default.OnLevelStarted -= SetLevel;
    }
    private void SetScore(float score, float maxScore)
    {
        _scoreText.text = score.ToString();
        if (score <= 0) _scoreText.text = "0";

    }
    private void SetLevel()
    {
        _levelText.text = $"Уровень {LevelManager.Default.CurrentLevelIndex}";
    }
}
