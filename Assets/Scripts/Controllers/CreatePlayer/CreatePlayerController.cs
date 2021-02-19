using System;
using System.Collections;
using System.Collections.Generic;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CreatePlayerController : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Button cancelButton;
    [SerializeField] private Button createButton;
    
    private UnityAction<Player> _createPlayerAction;
    private UnityAction _cancelAction;

    public void Initiate(UnityAction<Player> createPlayerAction, UnityAction cancelAction)
    {
        _createPlayerAction = createPlayerAction;
        _cancelAction = cancelAction;
    }

    private void Start()
    {
        cancelButton.onClick.AddListener(OnCancelButtonClicked);
        createButton.onClick.AddListener(OnCreatePlayerButtonClicked);
    }
    
    private void OnCreatePlayerButtonClicked()
    {
        if (string.IsNullOrEmpty(nameInputField.text))
            return;

        var createdPlayer = new Player(nameInputField.text);//TODO add action to create player
        _createPlayerAction.Invoke(createdPlayer);
    }

    private void OnCancelButtonClicked()
    {
        _cancelAction.Invoke();
    }
}
