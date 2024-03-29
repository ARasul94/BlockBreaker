﻿using System;
using System.Collections.Generic;
using Models;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Controllers.ChoosePlayer
{
    public class ChoosePlayerController : MonoBehaviour
    {
        [SerializeField] private PlayersTable playersTable;
        [SerializeField] private Transform playersContainer;
        [SerializeField] private ChoosePlayerElement playerPrefab;
        [SerializeField] private Button selectPlayerButton;
        [SerializeField] private Button createPlayerButton;
        [SerializeField] private Button backButton;

        private Player _selectedPlayer;
        private UnityAction<Player> _selectPlayerAction;
        private UnityAction _createPlayerAction;
        private UnityAction _cancelAction;
        private readonly List<ChoosePlayerElement> _playerElements = new List<ChoosePlayerElement>();

        private void OnEnable()
        {
            CreatePlayersList();
        }

        private void Start()
        {
            backButton.onClick.AddListener(OnCancelButtonClicked);
            selectPlayerButton.onClick.AddListener(OnSelectPlayerButtonClicked);
            createPlayerButton.onClick.AddListener(OnCreateButtonClicked);
        }

        private void OnDisable()
        {
            ClearElementsList();
        }

        private void ClearElementsList()
        {
            _playerElements.ForEach(x => Destroy(x.gameObject));
            _playerElements.Clear();
        }

        public void Initiate(UnityAction<Player> selectPlayerAction, UnityAction createPlayerAction, UnityAction cancelAction)
        {
            _selectPlayerAction = selectPlayerAction;
            _createPlayerAction = createPlayerAction;
            _cancelAction = cancelAction;
        }

        private void OnPlayerSelected(Player player)
        {
            _selectedPlayer = player;
        }
        
        private void DeletePlayer(Player player)
        {
            if (playersTable.RemovePlayer(player))
            {
                CreatePlayersList();
            }
        }

        private void OnSelectPlayerButtonClicked()
        {
            if (_selectedPlayer == null)
                return;
            
            _selectPlayerAction.Invoke(_selectedPlayer);
        }

        private void OnCancelButtonClicked()
        {
            _cancelAction.Invoke();
        }

        private void OnCreateButtonClicked()
        {
            _createPlayerAction.Invoke();
        }
        
        private void CreatePlayersList()
        {
            ClearElementsList();
            
            foreach (var player in playersTable.GetPlayers())
            {
                var playerElement = Instantiate(playerPrefab, playersContainer);
                playerElement.InitField(player, OnPlayerSelected, DeletePlayer);
                _playerElements.Add(playerElement);
            }
        }
    }
}
