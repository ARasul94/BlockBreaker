using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0, 3)][SerializeField] private float gameSpeed = 1;
    
    private int _score;
    private ScoreController _scoreController;

    private void Awake()
    {
        _scoreController = FindObjectOfType<ScoreController>();
    }

    private void Start()
    {
        _score = 0;
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddScore(int additionalScore)
    {
        _score += additionalScore;
        _scoreController.UpdateDisplayedScore(_score);
    }
}
