using System;
using System.Collections.Generic;
using Constants;
using Models;
using Newtonsoft.Json;
using ScriptableObjects;
using UnityEngine;

namespace Controllers
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private ScoreTable scoreTable;
        
        private int _breakableBlocksCount = 0;
        private SceneLoader _sceneLoader;
        private Level _levelInfo;
        private Player _player;
        private GameStatus _gameStatus;

        private void Awake()
        {
            _sceneLoader = FindObjectOfType<SceneLoader>();
            _gameStatus = FindObjectOfType<GameStatus>();
        }

        private void Start()
        {
            _levelInfo = scoreTable.GetLevelInfo(_sceneLoader.GetCurrentLevelName());
            var json = PlayerPrefs.GetString(PlayerInfoConstants.CURRENT_PLAYER);
            _player = JsonConvert.DeserializeObject<Player>(json);

            if (_player == null)
                throw new Exception("No player info ");
        }

        public void AddBreakableBlock()
        {
            _breakableBlocksCount++;
        }
    
        public void RemoveBreakableBlock()
        {
            _breakableBlocksCount--;

            if (_breakableBlocksCount <= 0)
            {
                scoreTable.UpdatePlayerLevelInfo(_levelInfo, _player, _gameStatus.Score);
                _sceneLoader.LoadNextScene();
            }
        }
    }
}
