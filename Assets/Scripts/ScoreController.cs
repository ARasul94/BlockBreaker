using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextfield;

    private void Start()
    {
        UpdateDisplayedScore(0);
    }

    public void UpdateDisplayedScore(int score)
    {
        scoreTextfield.text = score.ToString();
    }
}
