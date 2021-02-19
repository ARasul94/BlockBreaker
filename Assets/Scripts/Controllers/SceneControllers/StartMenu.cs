using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button startGameButton;

    public readonly UnityEvent OnStartClicked = new UnityEvent();

    private void Start()
    {
        startGameButton.onClick.AddListener(OnStartGameClicked);
    }

    private void OnStartGameClicked()
    {
        OnStartClicked.Invoke();
    }
}
