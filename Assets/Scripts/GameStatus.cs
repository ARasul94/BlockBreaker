using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0, 3)][SerializeField] private float gameSpeed = 1;

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }
}
