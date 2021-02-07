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
        scoreTextfield.text = string.Empty;
    }

    public void UpdateDisplayedScore(int score)
    {
        scoreTextfield.text = score.ToString();
    }
}
