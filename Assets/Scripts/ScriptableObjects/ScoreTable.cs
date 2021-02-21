using System;
using System.Collections.Generic;
using Models;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu][Serializable]
    public class ScoreTable : ScriptableObject
    {
        [SerializeField] private List<Level> levels = new List<Level>();
        private Dictionary<string, Level> _levels = new Dictionary<string, Level>();
        
        public void AddLevel(string levelName)
        {
            if (_levels.ContainsKey(levelName))
                return;
            
            var level = new Level(levelName);
            _levels.Add(level.Name, level);
            
            UpdateLevelsList();
        }
        
        public void RemoveLevel(string levelName)
        {
            if (_levels.ContainsKey(levelName))
                _levels.Remove(levelName);
        }

        public void RemovePlayerInfo(Player player)
        {
            foreach (var level in _levels.Values)
            {
                level.RemovePlayer(player.Id);
            }
            UpdateLevelsList();
        }

        private void UpdateLevelsList()
        {
            levels.Clear();
            levels.AddRange(_levels.Values);
            levels.Sort();
        }

        public void UpdatePlayerLevelInfo(string levelName, GUID playerId, int newResult)
        {
            if (!_levels.ContainsKey(levelName))
                return;
            var level = _levels[levelName];
            level.UpdatePlayerLevelInfo(playerId, newResult);
        }
    }
}
